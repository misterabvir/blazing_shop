using Domain.Base;

namespace Domain.Products.ValueObjects;

public record Discount : ValueObject
{
    public double Value { get; init; }
    private Discount(double value) => Value = value;
    public static Discount Create(double value) => new(value);
    public static Discount None => new(0);
}