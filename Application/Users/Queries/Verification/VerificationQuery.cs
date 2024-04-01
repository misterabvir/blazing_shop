using Application.Base.Repositories;
using Application.Base.Services;
using Application.Users.Responses;
using Domain.Users.Errors;
using Domain.Users.ValueObjects;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Shared.Results;

namespace Application.Users.Queries.Verification;

public record VerificationQuery(string Email, string Code) : IRequest<Result<TokenResult>>;

public class VerificationQueryHandler(IUserRepository userRepository, IMemoryCache cache, IJwtTokenService jwtTokenService) : IRequestHandler<VerificationQuery, Result<TokenResult>>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMemoryCache _cache = cache;
    private readonly IJwtTokenService _jwtTokenService = jwtTokenService;

    public async Task<Result<TokenResult>> Handle(VerificationQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(Email.Create(request.Email));
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        var code = _cache.Get<string>($"verification:{user.Id}");

        if (code == null || code != request.Code)
        {
            return Errors.User.InvalidCredentials;
        }

        _cache.Remove($"verification:{user.Id}");

        var token = _jwtTokenService.GetJwtToken(user);
        return new TokenResult(token);
    }
}
