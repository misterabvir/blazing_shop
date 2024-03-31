using Domain.Base;

namespace Domain.Categories.ValueObjects;

public record Icon : ValueObject
{
    public string Value { get; init; }
    private Icon(string value) => Value = value;
    public static Icon Create(string value) => new(value);
}
