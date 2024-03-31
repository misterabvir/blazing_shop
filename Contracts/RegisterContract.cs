using Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Contracts;

public class RegisterContract
{
    [Required]
    [MinLength(3)]
    public string Username { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string Phone { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [MinLength(3)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [Password]
    [MatchProperty(nameof(ConfirmPassword))]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Password]
    [MatchProperty(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;
}

