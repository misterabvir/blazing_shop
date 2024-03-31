using Shared.Results;

namespace Client.Services.ToastMessages;



public class ToastMessageService : IToastMessageService
{
    public Action<ToastMessage> OnMessageAdded { get; set; } = delegate { };

    public void AddErrorMessage(Error error)
    {               
        OnMessageAdded?.Invoke(ToastMessage.Error(error));
    }

    public void AddErrorMessage(List<Error> errors)
    {
        foreach (var error in errors)
        {
            AddErrorMessage(error);
        }
    }

    public void AddSuccessMessage(string message)
    {
        OnMessageAdded?.Invoke(ToastMessage.Success(message));
    }
}
