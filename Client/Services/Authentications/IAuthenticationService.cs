using Contracts.Authentications;
using Shared.Results;

namespace Client.Services.Authentications;

public interface IAuthenticationService
{
    Task<Result<TokenResponse>> Login(LoginRequest loginContract);
    Task<Result> Register(RegisterRequest registerContract);
    Task<Result<TokenResponse>> Verify(VerificationRequest verificationContract);
    Task<Result<AccountResponse>> GetProfile(string token);
    Task<Result> UpdateProfile(UpdateAccountRequest request, string token);
}
