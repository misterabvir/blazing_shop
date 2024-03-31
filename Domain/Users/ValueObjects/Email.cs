namespace Domain.Users.ValueObjects;

public record Email
{
    public string Value { get; init; }
    private Email(string value) => Value = value;
    public static Email Create(string value) => new(value);
}
