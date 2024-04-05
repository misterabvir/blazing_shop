using Domain.Base;

namespace Domain.Categories.ValueObjects;

public record PublishVariantId : ValueObject
{
    public Guid Value { get; init; }
    private PublishVariantId(Guid value) => Value = value;
    public static PublishVariantId CreateUnique() => new(Guid.NewGuid());
    public static PublishVariantId Create(Guid value) => new(value);
}

public record PublishVariantItemId : ValueObject
{
    public Guid Value { get; init; }
    private PublishVariantItemId(Guid value) => Value = value;
    public static PublishVariantItemId CreateUnique() => new(Guid.NewGuid());
    public static PublishVariantItemId Create(Guid value) => new(value);
}