using Contracts.Authentications;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Results;

namespace Client.Pages.Profiles
{
    public partial class ProfilePage
    {

        private DataAnnotationsValidator DataAnnotationsValidator { get; set; } = null!;
        private UpdateAccountRequest Model { get; set; } = new() { Avatar = "images/no-avatar.webp" };

        protected override void OnInitialized()
        {
            if (!string.IsNullOrEmpty(_account.Avatar))
            {
                Model.Avatar = _account.Avatar;
            }
            _account.Updated += AccountUpdateEvent;

        }

        private void AccountUpdateEvent()
        {
            if (!string.IsNullOrEmpty(_account.Avatar))
            {
                Model.Avatar = _account.Avatar;
            }
            Model.Username = _account.Username;
            Model.FirstName = _account.FirstName;
            Model.LastName = _account.LastName;
            StateHasChanged();
        }


        private async Task LoadFiles(InputFileChangeEventArgs e)
        {
            var buffer = new byte[e.File.Size];
            var resized = await e.File.RequestImageFileAsync(e.File.ContentType, 300, int.MaxValue);
            await resized.OpenReadStream().ReadAsync(buffer);
            Model.Avatar = $"data:{e.File.ContentType};base64,{Convert.ToBase64String(buffer)}";
        }

        private async Task UpdateProfileHandler(EditContext editContext)
        {
            if (!editContext.Validate())
            {
                _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
                return;
            }

            var token = await _sessionStorage.GetItem<string>("token");

            var result = await _authenticationService.UpdateProfile(Model, token);

            if (result.IsSuccess)
            {
                _toastMessageService.AddSuccessMessage("Profile updated successful");
                _account.FromUpdate(Model);
                StateHasChanged();
            }
        }
    }
}