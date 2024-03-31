using Domain.Base;
using Domain.Users.ValueObjects;

namespace Domain.Users.Owns;

public class Profile : Entity<ProfileId>
{
    private Profile() { }
    private Profile(ProfileId profileId, Username username, FirstName firstName, LastName lastName)
    {
        Id = profileId;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
    }

    public Username Username { get; private set; } = null!;
    public FirstName FirstName { get; private set; } = null!;
    public LastName LastName { get; private set; } = null!;
    public Avatar? Avatar { get; private set; } = null!;

    public static Profile Create(Username username, FirstName firstName, LastName lastName)
        => new(ProfileId.CreateUnique(), username, firstName, lastName);
}
