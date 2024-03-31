using Domain.Base;

namespace Domain.Users.ValueObjects;

public record UserId : ValueObject
{
    public Guid Value { get; init; }
    private UserId(Guid value) => Value = value;
    public static UserId Create(Guid value) => new(value);
    public static UserId CreateUnique() => new(Guid.NewGuid());
}
