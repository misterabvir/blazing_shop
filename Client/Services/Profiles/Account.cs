using Contracts.Authentications;

namespace Client.Services.Profiles;

public class Account
{
    public Guid UserId { get; private set; }
    public string Role { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public string Phone { get; private set; } = string.Empty;
    public string Username { get; private set; } = string.Empty;
    public string FirstName { get; private set; } = string.Empty;
    public string LastName { get; private set; } = string.Empty;
    public string Avatar { get; private set; } = string.Empty;

    public void FromResponse(AccountResponse response)
    {
        UserId = response.UserId;
        Role = response.Role;
        Email = response.Email;
        Phone = response.Phone;
        Username = response.Username;
        FirstName = response.FirstName;
        LastName = response.LastName;
        Avatar = response.Avatar ?? "images/no-avatar.webp";
        Updated.Invoke();
    }

    public void FromUpdate(UpdateAccountRequest request)
    {
        Username = request.Username;
        FirstName = request.FirstName;
        LastName = request.LastName;
        Avatar = request.Avatar;
        Updated.Invoke();
        
    }

    public Action Updated { get; set; } = delegate { };
}

