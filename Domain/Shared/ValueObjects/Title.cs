using Domain.Base;

namespace Domain.Shared.ValueObjects;

public record Title : ValueObject
{
    public string Value { get; init; }
    private Title(string value) => Value = value;
    public static Title Create(string value) => new(value);
}

