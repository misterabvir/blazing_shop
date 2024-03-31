using Domain.Base;

namespace Domain.Users.ValueObjects;

public record ContactId : ValueObject
{
    public Guid Value { get; init; }
    private ContactId(Guid value) => Value = value;
    public static ContactId Create(Guid value) => new(value);
    public static ContactId CreateUnique() => new(Guid.NewGuid());
}