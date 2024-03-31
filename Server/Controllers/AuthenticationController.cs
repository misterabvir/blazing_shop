using Contracts;
using Contracts.Authentications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.Results;

namespace Server.Controllers
{
    [Route("authentication")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        [HttpPost(template: "login")]
        public async Task<IActionResult> Login(LoginRequest loginContract)
        {
            await Task.CompletedTask;
            return Ok(Result.Success());
        }

        [HttpPost(template: "register")]
        public async Task<IActionResult> Register(RegisterRequest registerContract)
        {
            await Task.CompletedTask;
            return Ok(Result.Success());
        }

        [HttpPost(template: "verify")]
        public async Task<IActionResult> Verify(VerificationRequest verificationContract)
        {
            await Task.CompletedTask;
            return Ok(new TokenResponse("token"));
        }
    }
}
