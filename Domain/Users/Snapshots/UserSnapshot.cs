using Domain.Users.Owns;
using Domain.Users.ValueObjects;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Domain.Users.Snapshots;

public class UserSnapshot
{
    private UserSnapshot() { }

    public Guid Id { get; init; }
    public string Email { get; init; } = null!;
    public string Username { get; init; } = null!;
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string? Avatar { get; init; }
    public string Role { get; init; } = null!;
    public string Phone { get; init; } = null!;

    public static UserSnapshot Create(User user)
    {
        return new()
        {
            Id = user.Id.Value,
            Email = user.Contact.Email.Value,
            Phone = user.Contact.Phone.Value,
            Username = user.Profile.Username.Value,
            FirstName = user.Profile.FirstName.Value,
            LastName = user.Profile.LastName.Value,
            Role = user.Role.Value,
            Avatar = user.Profile.Avatar?.Value
        };
    }

    public string ToJson() => JsonConvert.SerializeObject(this);

}
