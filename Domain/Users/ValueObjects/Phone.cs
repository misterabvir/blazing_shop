namespace Domain.Users.ValueObjects;

public record Phone
{
    public string Value { get; init; }
    private Phone(string value) => Value = value;
    public static Phone Create(string value) => new(value);
}
