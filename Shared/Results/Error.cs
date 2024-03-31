namespace Shared.Results;

public record Error
{
    public Error(ErrorCode errorCode, string message, string? details = null)
    {
        ErrorCode = errorCode;
        Message = message;
        Details = details;
    }

    public Error() { }

    public ErrorCode ErrorCode { get; init; }
    public string Message { get; init; } = string.Empty;
    public string? Details { get; init; }


    public static Error NotFound(string message, string? details = null) => new(ErrorCode.NotFound, message, details);
    public static Error Validation(string message, string? details = null) => new(ErrorCode.Validation, message, details);
    public static Error Conflict(string message, string? details = null) => new(ErrorCode.Conflict, message, details);
    public static Error BadRequest(string message, string? details = null) => new(ErrorCode.BadRequest, message, details);
    public static Error InternalServerError(string message, string? details = null) => new(ErrorCode.InternalServerError, message, details);
}
