using Client.Services.Requests;
using Contracts;
using Shared.Results;

namespace Client.Services.Authentications;

public interface IAuthenticationService
{
    Task<Result> Login(LoginContract loginContract);
    Task<Result> Register(RegisterContract registerContract);
    Task<Result<TokenContract>> Verify(VerificationContract verificationContract);
}

public class AuthenticationService(IRequestService requestService) : IAuthenticationService
{
    private readonly IRequestService _requestService = requestService;
    
    public async Task<Result> Login(LoginContract loginContract)
    {
        return await _requestService.PostAsync("/authentication/login", loginContract);
    }

    public async Task<Result> Register(RegisterContract RegisterContract)
    {
        return await _requestService.PostAsync("/authentication/register", RegisterContract);
    }

    public async Task<Result<TokenContract>> Verify(VerificationContract verificationContract)
    {
        return await _requestService.PostAsync<TokenContract>("/authentication/verify", verificationContract);
    }
}
