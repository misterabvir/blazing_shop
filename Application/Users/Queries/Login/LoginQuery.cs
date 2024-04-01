using Application.Base.Repositories;
using Domain.Users.Errors;
using Domain.Users.ValueObjects;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Shared.Results;

namespace Application.Users.Queries.Login;
public record LoginQuery(string Email, string Password) : IRequest<Result>;

public class LoginQueryHandler(IUserRepository userRepository, ILogger<LoginQueryHandler> logger, IMemoryCache cache) : IRequestHandler<LoginQuery, Result>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ILogger<LoginQueryHandler> _logger = logger;
    private readonly IMemoryCache _cache = cache;

    public async Task<Result> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var email = Email.Create(request.Email);
        var user = await _userRepository.GetByEmail(email);
        if (user is null)
        {
            return Errors.User.InvalidCredentials;
        }

        if (!user.Security.Password.IsSameAs(user.Security.Salt.Hash(request.Password)))
        {
            return Errors.User.InvalidCredentials;
        }

        var code = Guid.NewGuid().ToString()[..6];
        _cache.Set($"verification:{user.Id}", code, TimeSpan.FromMinutes(5));
        _logger.LogInformation($"Verification code sent to {request.Email}: {code}");

        return Result.Success();
    }
}