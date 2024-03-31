using Domain.Base;

namespace Domain.Products.ValueObjects;

public record Image : ValueObject
{
    public string Value { get; init; }
    private Image(string value) => Value = value;
    public static Image Create(string value) => new(value);
}
