using Application.Base.Repositories;
using Application.Base.Services;
using Application.Users.Responses;
using Domain.Users.Errors;
using Domain.Users.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Users.Queries.Login;
public record LoginQuery(string Email, string Password) : IRequest<Result<TokenResult>>;

public class LoginQueryHandler(IUserRepository userRepository, IJwtTokenService jwtTokenService) : IRequestHandler<LoginQuery, Result<TokenResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

    public async Task<Result<TokenResult>> Handle(LoginQuery request, CancellationToken cancellationToken)
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

        var token = _jwtTokenService.GetJwtToken(user);

        return new TokenResult(token);
    }
}