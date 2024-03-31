using Client.Services.ToastMessages;

namespace Client.Layout
{
    public partial class MainLayout : IDisposable
    {
        protected override void OnInitialized()
        {
            _toastMessageService.OnMessageAdded += MessageAddedHandler;
        }

        private void MessageAddedHandler(ToastMessage message)
        {
            Messages.Add(message);
            StateHasChanged();
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                Messages.Remove(message);
                StateHasChanged();
            });
        }

        public List<ToastMessage> Messages { get; set; } = [];

        private async Task CloseEventHandler(ToastMessage message)
        {
            await Task.CompletedTask;
            Messages.Remove(message);
            StateHasChanged();
        }

        public void Dispose()
        {
#pragma warning disable CS8601
            _toastMessageService.OnMessageAdded -= MessageAddedHandler;
#pragma warning restore CS8601
        }
    }
}