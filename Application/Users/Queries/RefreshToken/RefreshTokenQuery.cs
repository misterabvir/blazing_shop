using Application.Base.Repositories;
using Application.Base.Services;
using Application.Users.Responses;
using Domain.Errors;
using Domain.Users.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Users.Queries.RefreshToken;

public record RefreshTokenQuery(Guid UserId) : IRequest<Result<TokenResult>>;
public class RefreshTokenQueryHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService) : IRequestHandler<RefreshTokenQuery, Result<TokenResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtTokenService _jwtTokenService = jwtTokenService;


    public async Task<Result<TokenResult>> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetById(UserId.Create(request.UserId));
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        var token = _jwtTokenService.GetJwtToken(user);
        return new TokenResult(token);
    }
}
