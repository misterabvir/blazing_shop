using Shared.Results;

namespace Client.Services.ToastMessages;

public interface IToastMessageService
{
    Action<ToastMessage> OnMessageAdded { get; set; }
    void AddErrorMessage(Error error);
    void AddErrorMessage(List<Error> errors);
    void AddSuccessMessage(string message);
}
