using Application.Base.Repositories;
using Domain.Errors;
using Domain.Users.ValueObjects;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Shared.Results;

namespace Application.Users.Queries.ConfirmVerificationCode;

public record ConfirmVerificationCodeQuery(string Email, string Code) : IRequest<Result>;

public class ConfirmVerificationCodeQueryHandler(IUserRepository userRepository, IMemoryCache cache) : IRequestHandler<ConfirmVerificationCodeQuery, Result>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMemoryCache _cache = cache;

    public async Task<Result> Handle(ConfirmVerificationCodeQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(Email.Create(request.Email));
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        var code = _cache.Get<string>($"verification:{user.Id}");
        if (code is null || code != request.Code)
        {
            return Errors.User.InvalidCredentials;
        }

        _cache.Remove($"verification:{user.Id}");

        return Result.Success();
    }
}

