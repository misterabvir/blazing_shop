namespace Domain.Users.ValueObjects;

public record Avatar
{
    public string Value { get; init; }
    private Avatar(string value) => Value = value;
    public static Avatar Create(string value) => new(value);
}
