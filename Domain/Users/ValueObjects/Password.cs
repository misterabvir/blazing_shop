using Domain.Base;

namespace Domain.Users.ValueObjects;

public record Password : ValueObject
{
    public byte[] Value { get; init; }
    private Password(byte[] value) => Value = value;
    public static Password Create(byte[] value) => new(value);
    public bool IsSameAs(Password password) => Value.SequenceEqual(password.Value);
}
