using Domain.Base;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Domain.Users.ValueObjects;

public record Salt : ValueObject
{
    public byte[] Value { get; init; }
    private Salt(byte[] value) => Value = value;
    public static Salt Create(byte[] value) => new(value);
    public static Salt CreateUnique() => new(Guid.NewGuid().ToByteArray());
    public Password Hash(string password) =>
        Password.Create(KeyDerivation.Pbkdf2(
            password: password,
            salt: Value,
            prf: KeyDerivationPrf.HMACSHA512,
            iterationCount: 10000,
            numBytesRequested: 512 / 8));
}