namespace Shared.Results;

public sealed class Result<T> : Result
{
    private Result(T value) : base() => Value = value;
    private Result(List<Error> errors) : base(errors) { }
    private Result(Error error) : base(error) { }
    public T? Value { get; set; }

    public static Result<T> Success(T value) => new(value);
    public static implicit operator Result<T>(Error error) => new(error);
    public static implicit operator Result<T>(List<Error> errors) => new(errors);
    public static implicit operator Result<T>(T value) => new(value);

}
