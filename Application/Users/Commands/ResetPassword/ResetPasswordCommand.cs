using Application.Base.Repositories;
using Domain.Errors;
using Domain.Users.Entities;
using Domain.Users.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Users.Commands.ResetPassword;

public record ResetPasswordCommand(string Email, string Password):IRequest<Result>;

public class ResetPasswordCommandHandler(IUserRepository userRepository) : IRequestHandler<ResetPasswordCommand, Result>
{
    private readonly IUserRepository _userRepository = userRepository;
    
    public async Task<Result> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(Email.Create(request.Email));
        if(user is null)
        {
            return Errors.User.NotFound;
        }

        user.UpdateSecurity(Security.Create(request.Password));

        await _userRepository.Update(user);

        return Result.Success();
    }
}
