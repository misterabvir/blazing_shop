using Domain.Base;

namespace Domain.Users.ValueObjects;

public record ProfileId : ValueObject
{
    public Guid Value { get; init; }
    private ProfileId(Guid value) => Value = value;
    public static ProfileId Create(Guid value) => new(value);
    public static ProfileId CreateUnique() => new(Guid.NewGuid());
}