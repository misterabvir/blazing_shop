using Application.Base.Repositories;
using Domain.Users.Errors;
using Domain.Users.ValueObjects;
using MediatR;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Shared.Results;

namespace Application.Users.Queries.SendVerificationCode;

public record SendVerificationCodeQuery(string Email):IRequest<Result>;
public class ResetPasswordVerificationQueryHandler(
    IUserRepository userRepository,
    ILogger<ResetPasswordVerificationQueryHandler> logger,
    IMemoryCache cache) : IRequestHandler<SendVerificationCodeQuery, Result>
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly ILogger<ResetPasswordVerificationQueryHandler> _logger = logger;
    private readonly IMemoryCache _cache = cache;
    
    
    public async Task<Result> Handle(SendVerificationCodeQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmail(Email.Create(request.Email));
        if(user is null)
        {
            return Errors.User.NotFound;
        }

        var code = Guid.NewGuid().ToString()[..6];
        _cache.Set($"verification:{user.Id}", code, TimeSpan.FromMinutes(5));
        _logger.LogInformation($"Verification code sent to {request.Email}: {code}");

        return Result.Success();
    }
}
