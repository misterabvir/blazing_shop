namespace Domain.Users.ValueObjects;

public record FirstName
{
    public string Value { get; init; }
    private FirstName(string value) => Value = value;
    public static FirstName Create(string value) => new(value);
}
