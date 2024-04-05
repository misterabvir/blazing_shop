using Domain.Base;
using Domain.Users.Entities;
using Domain.Users.ValueObjects;

namespace Domain.Users;

public class User : AggregateRoot<UserId>
{
    private User() { }
    private User(UserId userId, Profile profile, Contact contact, Security @private, Role role)
    {
        Id = userId;
        Profile = profile;
        Contact = contact;
        Security = @private;
        Role = role;
    }
    public Profile Profile { get; private set; } = null!;
    public Role Role{ get; private set; } = null!;
    public Contact Contact { get; private set; } = null!;
    public Security Security { get; private set; } = null!;
    public static User Create(Profile profile, Contact contact, Security @private, Role role)
        => new(UserId.CreateUnique(), profile, contact, @private, role);
   
    public void UpdateProfile(Profile profile)
    {
        Profile.Update(profile);
    }

    public void UpdateSecurity(Security security)
    {
        Security.Update(security);  
    }
}
