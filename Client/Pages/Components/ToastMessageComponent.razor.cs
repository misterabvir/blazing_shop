using Client.Services.ToastMessages;
using Microsoft.AspNetCore.Components;

namespace Client.Pages.Components
{
    public partial class ToastMessageComponent
    {
        [Parameter]
        public ToastMessage Message { get; set; } = null!;
        [Parameter]
        public EventCallback<ToastMessage> OnCloseEvent { get; set; }

        private string BackgroundCssClass { get; set; } = "";

        protected override void OnInitialized()
        {
            BackgroundCssClass = Message.Type switch
            {
                ToastMessageType.Info => "info-bg",
                ToastMessageType.Success => "success-bg",
                ToastMessageType.Error => "danger-bg",
                _ => "warning-bg",
            };
        }


        private async Task Close()
        {
            await OnCloseEvent.InvokeAsync(Message);
        }
    }
}