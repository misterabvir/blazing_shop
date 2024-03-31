using Domain.Users;
using Domain.Users.Owns;
using Domain.Users.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

internal class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> user)
    {
        user.ToTable("users", "accounts");

        user.HasKey(u => u.Id).HasName("pk_users");
        user.Property(u => u.Id)
            .HasConversion(id => id.Value, value => UserId.Create(value))
            .HasColumnName("user_id")
            .ValueGeneratedNever();

        user.Property(u => u.Role).HasConversion(role => role.Value, value => Role.Create(value));

        user.OwnsOne(u => u.Contact, ContactConfigure);
        user.OwnsOne(u => u.Profile, ProfileConfigure);
        user.OwnsOne(u => u.Security, SecurityConfigure);


    }

    private void ContactConfigure(OwnedNavigationBuilder<User, Contact> contact)
    {
        contact.ToTable("contacts", "accounts");
        contact.WithOwner().HasForeignKey("user_id");
        contact.HasKey("Id", "user_id").HasName("pk_contacts");
        contact.Property(c => c.Id).HasConversion(id => id.Value, value => ContactId.Create(value)).HasColumnName("contact_id");
        contact.Property(c => c.Email).HasConversion(email => email.Value, value => Email.Create(value));
        contact.Property(c => c.Phone).HasConversion(phone => phone.Value, value => Phone.Create(value));
    }

    private void ProfileConfigure(OwnedNavigationBuilder<User, Profile> profile)
    {
        profile.ToTable("profiles", "accounts");
        profile.WithOwner().HasForeignKey("user_id");
        profile.HasKey("Id", "user_id").HasName("pk_profiles");
        profile.Property(p => p.Id).HasConversion(id => id.Value, value => ProfileId.Create(value)).HasColumnName("profile_id");
        profile.Property(p => p.Username).HasConversion(username => username.Value, value => Username.Create(value));
        profile.Property(p => p.FirstName).HasConversion(firstName => firstName.Value, value => FirstName.Create(value));
        profile.Property(p => p.LastName).HasConversion(lastName => lastName.Value, value => LastName.Create(value));
        profile.Property(p => p.Avatar).HasConversion(avatar => avatar == null ? null : avatar.Value, value => value == null ? null : Avatar.Create(value));
    }

    private void SecurityConfigure(OwnedNavigationBuilder<User, Security> security)
    {
        security.ToTable("security", "accounts");
        security.WithOwner().HasForeignKey("user_id");
        security.HasKey("Id", "user_id").HasName("pk_security");
        security.Property(s => s.Id).HasConversion(id => id.Value, value => SecurityId.Create(value)).HasColumnName("security_id");
        security.Property(s => s.Password).HasConversion(password => password.Value, value => Password.Create(value));
        security.Property(s => s.Salt).HasConversion(salt => salt.Value, value => Salt.Create(value));
    }

}
