using Application.Base.Repositories;
using Domain.Errors;
using Domain.Users.ValueObjects;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Shared.Results;

namespace Application.Users.Queries.RepeatVerification;

public record RepeatVerificationQuery(string Email) : IRequest<Result>;

public class RepeatVerificationQueryHandler(IUserRepository userRepository, IMemoryCache cache, ILogger<RepeatVerificationQueryHandler> logger) : IRequestHandler<RepeatVerificationQuery, Result>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IMemoryCache _cache = cache;
    private readonly ILogger<RepeatVerificationQueryHandler> _logger = logger;


    public async Task<Result> Handle(RepeatVerificationQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(Email.Create(request.Email));
        if (user is null)
        {
            return Errors.User.NotFound;
        }

        _cache.Remove($"verification:{user.Id}");
        var code = Guid.NewGuid().ToString()[..6];
        _cache.Set($"verification:{user.Id}", code, TimeSpan.FromMinutes(5));
        _logger.LogInformation($"Verification code sent to {request.Email}: {code}");

        return Result.Success();
    }
}
