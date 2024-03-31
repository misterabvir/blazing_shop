using Contracts.Authentications;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Results;

namespace Client.Pages.Authentication
{
    public partial class Login
    {
        DataAnnotationsValidator DataAnnotationsValidator { get; set; } = null!;
        private LoginRequest Model { get; set; } = new();
        private VerificationRequest VerificationModel { get; set; } = new();
        private bool IsLogInSuccess { get; set; } = false;


        private async Task TryLogin(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }
            var result = await _authenticationService.Login(Model);
            IsLogInSuccess = result.IsSuccess;
            if (!result.IsSuccess)
            {
                _toastMessageService.AddErrorMessage(result.Errors);
            }
            else
            {
                _toastMessageService.AddSuccessMessage("Log In was success, input send code for confirm your credentials");
                VerificationModel.Email = Model.Email;
            }
        }

        private async Task TryVerify(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }

            var result = await _authenticationService.Verify(VerificationModel);
            if (!result.IsSuccess)
            {
                _toastMessageService.AddErrorMessage(result.Errors);
            }
            else
            {
                _toastMessageService.AddSuccessMessage("Code confirmed successful");
            }
        }
    }
}