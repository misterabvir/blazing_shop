using Client.Services.Requests;
using Contracts.Authentications;
using Shared.Results;

namespace Client.Services.Authentications;

public class AuthenticationService(IRequestService requestService) : IAuthenticationService
{
    private readonly IRequestService _requestService = requestService;

    public async Task<Result<AccountResponse>> GetProfile(string token)
    {
        return await _requestService.GetAsync<AccountResponse>("/authentication/profile", token);
    }

    public async Task<Result<TokenResponse>> Login(LoginRequest loginContract)
    {
        return await _requestService.PostAsync<TokenResponse>("/authentication/login", loginContract);
    }

    public async Task<Result> Register(RegisterRequest RegisterContract)
    {
        return await _requestService.PostAsync("/authentication/register", RegisterContract);
    }

    public async Task<Result> UpdateProfile(UpdateAccountRequest request, string token)
    {
         return await _requestService.PutAsync("/authentication/profile", request, token);
    }

    public async Task<Result<TokenResponse>> Verify(VerificationRequest verificationContract)
    {
        return await _requestService.PostAsync<TokenResponse>("/authentication/verify", verificationContract);
    }
}
