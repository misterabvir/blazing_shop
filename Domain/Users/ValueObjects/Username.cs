namespace Domain.Users.ValueObjects;

public record Username
{
    public string Value { get; init; }
    private Username(string value) => Value = value;
    public static Username Create(string value) => new(value);
}
