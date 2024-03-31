using Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentications;

public class LoginRequest
{

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Password]
    public string Password { get; set; } = string.Empty;
}

