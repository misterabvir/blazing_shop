using Domain.Base;

namespace Domain.Categories.ValueObjects;

public record CategoryId : ValueObject
{
    public Guid Value { get; init; }
    private CategoryId(Guid value) => Value = value;
    public static CategoryId Create(Guid value) => new(value);
    public static CategoryId CreateUnique() => new(Guid.NewGuid());
}
