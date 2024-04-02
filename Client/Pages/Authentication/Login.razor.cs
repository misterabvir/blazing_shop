using Contracts.Authentications;
using Microsoft.AspNetCore.Components.Forms;
using Shared.Results;

namespace Client.Pages.Authentication;

public partial class Login
{
    DataAnnotationsValidator DataAnnotationsValidator { get; set; } = null!;
    private LoginRequest Model { get; set; } = new();

    protected override void OnInitialized()
    {
        if (_authenticationStateProvider.IsAuthenticated)
        {
            _navigation.NavigateTo("/");
        }
    }

    private async Task TryLogin(EditContext editContext)
    {
        if (!editContext.Validate())
        {
            _toastMessageService.AddErrorMessage(Error.Validation("Some fields are not valid"));
            return;
        }
        var result = await _authenticationService.Login(Model);
        if (result.IsFailure)
        {
            _toastMessageService.AddErrorMessage(result.Errors);
        }
        else
        {
            _toastMessageService.AddSuccessMessage("Log In was success");
            _authenticationStateProvider.NotifyUserLogIn(result.Value!.Token);
            _navigation.NavigateTo("/");
        }
    }
}