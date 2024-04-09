using Contracts.Authentications;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Results;

namespace Client.Pages.Authentication
{
    public partial class ForgotPassword
    {
        private SendVerificationCodeRequest SendCodeModel { get; set; } = new();
        private ConfirmVerificationCodeRequest ConfirmCodeModel { get; set; } = new();
        private ResetPasswordRequest ResetModel { get; set; } = new();
        private State StateModel { get; set; } = State.Send;
        private bool IsDisabled { get; set; } = false;
        private string DisabledTime { get; set; } = string.Empty;


        private async Task Delay()
        {
            for (int i = 5; i > 0; i--)
            {
                DisabledTime = $"repeat send after {i} seconds";
                await Task.Delay(i * 1000);
                StateHasChanged();
            }
            DisabledTime = "";
            IsDisabled = false;
            StateHasChanged();
        }

        private async Task TrySendCodeVerification(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }
            IsDisabled = true;
            await Task.Factory.StartNew(Delay).ConfigureAwait(false);

            var result = await _authenticationService.SendVerificationCode(SendCodeModel);
            if (result.IsSuccess)
            {
                ConfirmCodeModel.Email = SendCodeModel.Email;
                _toastMessageService.AddSuccessMessage($"Code was send successful to {SendCodeModel.Email}");
            }
        }

        private async Task TryConfirmCodeVerification(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }
            var result = await _authenticationService.ConfirmVerificationCode(ConfirmCodeModel);
            if (result.IsSuccess)
            {
                ResetModel.Email = ConfirmCodeModel.Email;
                StateModel = State.Reset;
                _toastMessageService.AddSuccessMessage($"The verification code confirmed successful for {ConfirmCodeModel.Email}");
            }
        }


        private async Task TryResetPassword(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }
            var result = await _authenticationService.ResetPassword(ResetModel);
            if (result.IsFailure)
            {
                StateModel = State.Send;
            }
            else
            {
                _toastMessageService.AddSuccessMessage($"Your password was changed, now try log in");
                _navigation.NavigateTo("/authentication/login");
            }
        }

        private enum State
        {
            Send,
            Reset
        }
    }
}