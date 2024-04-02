using Contracts.Authentications;
using Shared.Results;

namespace Client.Services.Authentications;

public interface IAuthenticationService
{
    Task<Result<TokenResponse>> Login(LoginRequest request);
    Task<Result> Register(RegisterRequest request);
    Task<Result<TokenResponse>> Verify(VerificationRequest request);
    Task<Result<AccountResponse>> GetProfile(string token);
    Task<Result> UpdateProfile(UpdateAccountRequest request, string token);
    Task<Result> SendVerificationCode(SendVerificationCodeRequest request);
    Task<Result> ConfirmVerificationCode(ConfirmVerificationCodeRequest request);
    Task<Result> ResetPassword(ResetPasswordRequest request);
}
