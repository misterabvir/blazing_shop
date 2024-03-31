using Domain.Base;

namespace Domain.Users;

public record Role : ValueObject
{
    public string Value { get; init; }
    private Role(string value) => Value = value;
    public static Role Create(string value) => new(value);
    public static Role Administrator => new("administrator");
    public static Role Customer => new("customer");
}