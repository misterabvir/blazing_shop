using Domain.Base;

namespace Domain.Products.ValueObjects;

public record VariantId : ValueObject
{
    public Guid Value { get; init; }
    private VariantId(Guid value) => Value = value;
    public static VariantId Create(Guid value) => new(value);
    public static VariantId CreateUnique() => new(Guid.NewGuid());
}
