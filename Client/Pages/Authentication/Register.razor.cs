using Contracts.Authentications;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Results;

namespace Client.Pages.Authentication
{
    public partial class Register
    {
        private RegisterRequest Model { get; set; } = new();
        private VerificationRequest VerificationModel { get; set; } = new();

        private bool IsRegisterSuccess { get; set; } = false;


        protected override void OnInitialized()
        {
            if(_authenticationStateProvider.IsAuthenticated)
            {
                _navigation.NavigateTo("/");
            }
        }

        private async Task TryRegister(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }
            var result = await _authenticationService.Register(Model);
            IsRegisterSuccess = result.IsSuccess;
            if (result.IsSuccess)
            {
                _toastMessageService.AddSuccessMessage("Sign In was success, input send code for confirm your credentials");
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
            if (result.IsSuccess)
            {
                _toastMessageService.AddSuccessMessage("Code confirmed successful");
                _authenticationStateProvider.NotifyUserLogIn(result.Value!.Token);
                _navigation.NavigateTo("/");
            }
        }
    }
}