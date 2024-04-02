using Application.Base.Repositories;
using Domain.Errors;
using Domain.Users;
using Domain.Users.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Users.Queries.GetAccount;

public record GetAccountQuery(Guid UserId) : IRequest<Result<User>>;

public class GetAccountQueryHandler(IUserRepository userRepository) : IRequestHandler<GetAccountQuery, Result<User>>
{
    private readonly IUserRepository _userRepository = userRepository;

    public async Task<Result<User>> Handle(GetAccountQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(UserId.Create(request.UserId));
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        return user;
    }
}
