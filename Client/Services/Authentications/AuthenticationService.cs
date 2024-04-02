using Client.Services.Requests;
using Contracts.Authentications;
using Shared.Results;

namespace Client.Services.Authentications;

public class AuthenticationService(IRequestService requestService) : IAuthenticationService
{
    private readonly IRequestService _requestService = requestService;

    public async Task<Result> ConfirmVerificationCode(ConfirmVerificationCodeRequest request)
    {
        return await _requestService.PostAsync("/authentication/confirm-code-verification", request);
    }

    public async Task<Result<AccountResponse>> GetProfile(string token)
    {
        return await _requestService.GetAsync<AccountResponse>("/authentication/profile", token);
    }

    public async Task<Result<TokenResponse>> Login(LoginRequest request)
    {
        return await _requestService.PostAsync<TokenResponse>("/authentication/login", request);
    }

    public async Task<Result> Register(RegisterRequest request)
    {
        return await _requestService.PostAsync("/authentication/register", request);
    }

    public async Task<Result> ResetPassword(ResetPasswordRequest request)
    {
        return await _requestService.PostAsync("/authentication/reset-password", request);
    }

    public async Task<Result> SendVerificationCode(SendVerificationCodeRequest request)
    {
        return await _requestService.PostAsync("/authentication/send-code-verification", request);
    }

    public async Task<Result> UpdateProfile(UpdateAccountRequest request, string token)
    {
         return await _requestService.PutAsync("/authentication/profile", request, token);
    }

    public async Task<Result<TokenResponse>> Verify(VerificationRequest request)
    {
        return await _requestService.PostAsync<TokenResponse>("/authentication/verify", request);
    }
}
