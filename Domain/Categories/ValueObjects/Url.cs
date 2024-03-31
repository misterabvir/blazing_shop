using Domain.Base;

namespace Domain.Categories.ValueObjects;

public record Url : ValueObject
{
    public string Value { get; init; }
    private Url(string value) => Value = value;
    public static Url Create(string value) => new(value);
}
