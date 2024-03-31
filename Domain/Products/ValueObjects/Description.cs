using Domain.Base;

namespace Domain.Products.ValueObjects;

public record Description : ValueObject
{
    public string Value { get; init; }
    private Description(string value) => Value = value;
    public static Description Create(string value) => new(value);
}
