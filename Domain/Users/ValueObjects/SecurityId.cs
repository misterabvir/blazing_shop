using Domain.Base;

namespace Domain.Users.ValueObjects;

public record SecurityId : ValueObject
{
    public Guid Value { get; init; }
    private SecurityId(Guid value) => Value = value;
    public static SecurityId Create(Guid value) => new(value);
    public static SecurityId CreateUnique() => new(Guid.NewGuid());
}