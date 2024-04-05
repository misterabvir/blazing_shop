using Domain.Base;
using Domain.Users.ValueObjects;

namespace Domain.Users.Entities;

public class Contact : Entity<ContactId>
{
    private Contact() { }
    private Contact(ContactId contactId, Email email, Phone phone)
    {
        Id = contactId;
        Email = email;
        Phone = phone;
    }

    public Email Email { get; private set; } = null!;
    public Phone Phone { get; private set; } = null!;
    public static Contact Create(Email email, Phone phone) => new(ContactId.CreateUnique(), email, phone);
}
