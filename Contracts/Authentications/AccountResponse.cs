namespace Contracts.Authentications;

public record AccountResponse(
    Guid UserId,
    string Role,
    string Email,
    string Phone,
    string Username,
    string FirstName,
    string LastName,
    string? Avatar
    );

