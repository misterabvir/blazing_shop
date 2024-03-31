using Domain.Base;

namespace Domain.Products.ValueObjects;

public record Price : ValueObject
{
    public decimal Value { get; init; }
    private Price(decimal value) => Value = value;
    public static Price Create(decimal value) => new(value);

    public static bool operator >(Price? left, Price? right) =>
        left is not null &&
        right is not null &&
        left.Value > right.Value;

    public static bool operator >=(Price? left, Price? right) =>
        left is not null &&
        right is not null &&
        left.Value >= right.Value;

    public static bool operator <(Price? left, Price? right) =>
        left is not null &&
        right is not null &&
        left.Value < right.Value;

    public static bool operator <=(Price? left, Price? right) =>
        left is not null &&
        right is not null &&
        left.Value <= right.Value;
}
