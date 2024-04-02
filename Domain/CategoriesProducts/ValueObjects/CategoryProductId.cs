using Domain.Base;

namespace Domain.CategoriesProducts.ValueObjects;

public record CategoryProductId : ValueObject
{
    public Guid Value { get; private set; }
    private CategoryProductId(Guid value) => Value = value;
    public static CategoryProductId CreateUnique() => new(Guid.NewGuid());
    public static CategoryProductId Create(Guid value) => new(value);
}