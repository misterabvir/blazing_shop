using Application.Users.Queries.Verification;
using Contracts.Authentications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Server.Common.Extensions;
using System.Security.Claims;
using Application.Users.Queries.RepeatVerification;
using Application.Users.Queries.RefreshToken;
using Application.Users.Queries.GetAccount;
using Server.Common.Endpoints;
using Application.Users.Commands.UpdateAccount;

namespace Server.Controllers
{
    [Route(EndPoints.User.Controller)]
    [ApiController]
    [AllowAnonymous]
    public class AuthenticationController(ISender sender) : ControllerBase
    {
        private readonly ISender _sender = sender;

        [HttpPost(EndPoints.User.Post.Login)]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var query = request.Map();
            var result = await _sender.Send(query);
            return result.Map().Match(Ok, BadRequest);
        }

        [HttpPost(EndPoints.User.Post.Register)]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var command = request.Map();
            var result = await _sender.Send(command);
            return result.Match(Ok, BadRequest);
        }

        [HttpPost(EndPoints.User.Post.Verify)]
        public async Task<IActionResult> Verify(VerificationRequest request)
        {
            var query = new VerificationQuery(request.Email, request.Code);
            var result = await _sender.Send(query);
            return result.Map().Match(Ok, BadRequest);

        }

        [HttpPost(EndPoints.User.Post.RepeatVerification)]
        public async Task<IActionResult> RepeatVerification(RepeatVerificationRequest request)
        {
            var query = new RepeatVerificationQuery(request.Email);
            var result = await _sender.Send(query);
            return result.Match(Ok, BadRequest);
        }

        [Authorize]
        [HttpGet(EndPoints.User.Get.RefreshToken)]
        public async Task<IActionResult> RefreshToken()
        {
            var userId = Guid.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var query = new RefreshTokenQuery(userId);
            var result = await _sender.Send(query);
            return result.Map().Match(Ok, BadRequest);
        }

        [Authorize]
        [HttpGet(EndPoints.User.Get.Profile)]
        public async Task<IActionResult> GetAccount()
        {
            var userId = Guid.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var query = new GetAccountQuery(userId);
            var result = await _sender.Send(query);
            return result.Map().Match(Ok, BadRequest);
        }

        [Authorize]
        [HttpPut(EndPoints.User.Get.Profile)]
        public async Task<IActionResult> UpdateAccount(UpdateAccountRequest request)
        {
            var userId = Guid.Parse(HttpContext.User.Claims.First(x => x.Type == ClaimTypes.NameIdentifier).Value);
            var query = new UpdateAccountCommand(userId, request.Username, request.FirstName, request.LastName, request.Avatar);
            var result = await _sender.Send(query);
            return result.Match(Ok, BadRequest);
        }
    }
}
