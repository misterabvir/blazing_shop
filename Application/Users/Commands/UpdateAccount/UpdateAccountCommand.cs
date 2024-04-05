using Application.Base.Repositories;
using Domain.Errors;
using Domain.Users.Entities;
using Domain.Users.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Users.Commands.UpdateAccount;

public record UpdateAccountCommand(Guid UserId, string Username, string FirstName, string LastName, string Avatar) : IRequest<Result>;

public class UpdateAccountCommandHandler(IUserRepository userRepository) : IRequestHandler<UpdateAccountCommand, Result>
{
    private readonly IUserRepository _userRepository = userRepository;
    
    public async Task<Result> Handle(UpdateAccountCommand request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(UserId.Create(request.UserId));
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        var profile = Profile.Create(Username.Create(request.Username), FirstName.Create(request.FirstName), LastName.Create(request.LastName), Avatar.Create(request.Avatar));
        user.UpdateProfile(profile);

        await _userRepository.Update(user);

        return Result.Success();
    }
}
