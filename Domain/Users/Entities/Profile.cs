using Domain.Base;
using Domain.Users.ValueObjects;

namespace Domain.Users.Entities;

public class Profile : Entity<ProfileId>
{
    private Profile() { }
    private Profile(ProfileId profileId, Username username, FirstName firstName, LastName lastName, Avatar? avatar = null)
    {
        Id = profileId;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        Avatar = avatar;
    }

    public Username Username { get; private set; } = null!;
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public Avatar? Avatar { get; private set; } = null!;

    public static Profile Create(Username username, FirstName firstName, LastName lastName, Avatar? avatar = null)
        => new(ProfileId.CreateUnique(), username, firstName, lastName, avatar);

    internal void Update(Profile profile)
    {
        Username = profile.Username;
        FirstName = profile.FirstName;
        LastName = profile.LastName;
        Avatar = profile.Avatar;
    }
}
