using Domain.Base;

namespace Domain.Products.ValueObjects;

public record Date : ValueObject
{
    public DateTime Value { get; init; }
    private Date(DateTime value) => Value = value;
    public static Date Create(DateTime value) => new(value);
    public static Date Now => new(DateTime.UtcNow);
}
