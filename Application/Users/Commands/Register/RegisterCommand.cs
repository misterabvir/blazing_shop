using Application.Base.Repositories;
using Domain.Errors;
using Domain.Users;
using Domain.Users.Owns;
using Domain.Users.ValueObjects;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Shared.Results;

namespace Application.Users.Commands.Register;

public record RegisterCommand(
    string Username,
    string Email,
    string Phone,
    string FirstName,
    string LastName,
    string Password)
    : IRequest<Result>;

public class RegisterCommandHandler(IUserRepository userRepository, ILogger<RegisterCommandHandler> logger, IMemoryCache cache) : IRequestHandler<RegisterCommand, Result>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ILogger<RegisterCommandHandler> _logger = logger;
    private readonly IMemoryCache _cache = cache;

    public async Task<Result> Handle(RegisterCommand request, CancellationToken cancellationToken)
    {
        var username = Username.Create(request.Username);
        var email = Email.Create(request.Email);
        var phone = Phone.Create(request.Phone);

        if (await _userRepository.IsUsernameNotUnique(username))
            return Errors.User.UsernameAlreadyTaken;
        if (await _userRepository.IsEmailNotUnique(email))
            return Errors.User.EmailAlreadyTaken; ;
        if (await _userRepository.IsPhoneNotUnique(phone))
            return Errors.User.PhoneNumberAlreadyTaken;

        var profile = Profile.Create(username, FirstName.Create(request.FirstName), LastName.Create(request.LastName));
        var security = Security.Create(request.Password);
        var contact = Contact.Create(email, phone);

        var role = await _userRepository.IsUsersExist() ? Role.Customer : Role.Administrator;

        var user = User.Create(profile, contact, security, role);

        await _userRepository.Add(user);

        var code = Guid.NewGuid().ToString()[..6];
        _cache.Set($"verification:{user.Id}", code, TimeSpan.FromMinutes(5));
        _logger.LogInformation($"Verification code sent to {request.Email}: {code}");

        return Result.Success();
    }

}

