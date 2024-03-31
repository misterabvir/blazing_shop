namespace Shared.Results;

public enum ErrorCode
{
    NotFound = 404,
    Conflict = 409,
    BadRequest = 400,
    InternalServerError = 500,
    Validation = 422,
}