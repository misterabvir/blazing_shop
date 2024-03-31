using Domain.Base;

namespace Domain.Products.ValueObjects;

public record ProductId : ValueObject
{
    public Guid Value { get; init; }
    private ProductId(Guid value) => Value = value;
    public static ProductId Create(Guid value) => new(value);
    public static ProductId CreateUnique() => new(Guid.NewGuid());
}
