using Contracts;
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
        public async Task<IActionResult> Login(LoginContract loginContract)
        {
            await Task.CompletedTask;
            return Ok(Result.Success());
        }

        [HttpPost(template: "register")]
        public async Task<IActionResult> Register(RegisterContract registerContract)
        {
            await Task.CompletedTask;
            return Ok(Result.Success());
        }

        [HttpPost(template: "verify")]
        public async Task<IActionResult> Verify(VerificationContract verificationContract)
        {
            await Task.CompletedTask;
            return Ok(new TokenContract("token"));
        }
    }
}
