using Shared.Results;

namespace Client.Services.ToastMessages;

public record  ToastMessage
{
    public string Title { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public ToastMessageType Type { get; set; } = ToastMessageType.Info;

    public static ToastMessage Error(Error error)
    {
        return new ToastMessage()
        {
            Title = error.Message,
            Text = error.Details ?? string.Empty,
            Type = ToastMessageType.Error,
        };
    }

    public static ToastMessage Success(string message) 
    {
        return new ToastMessage()
        {
            Title = "Success",
            Text = message,
            Type = ToastMessageType.Success,
        };
    
    }
}
