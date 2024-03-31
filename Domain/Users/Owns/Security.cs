using Domain.Base;
using Domain.Users.ValueObjects;

namespace Domain.Users.Owns;

public class Security : Entity<SecurityId>
{
    private Security() { } // EF
    private Security(SecurityId privateId, Password password, Salt salt)
    {
        Id = privateId;
        Password = password;
        Salt = salt;
    }
    public Password Password { get; private set; } = null!;
    public Salt Salt { get; private set; } = null!;

    public static Security Create(Password password, Salt salt) => new(SecurityId.CreateUnique(), password, salt);
    public static Security Create(string password)
    {
        var salt = Salt.CreateUnique();
        var passwordHash = salt.Hash(password);
        return new Security(SecurityId.CreateUnique(), passwordHash, salt);
    }
}