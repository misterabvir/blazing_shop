namespace Shared.Results;

public class Result
{
    public bool IsSuccess => Errors.Count == 0;
    public bool IsFailure => !IsSuccess;
    public List<Error> Errors { get; } = [];
    protected Result(List<Error> errors) => Errors = errors;
    protected Result(Error error) => Errors = [error];
    protected Result() {}

    public static Result Success() => new();
    public static implicit operator Result(Error error) => new(error);
    public static implicit operator Result(List<Error> errors) => new(errors);
}
