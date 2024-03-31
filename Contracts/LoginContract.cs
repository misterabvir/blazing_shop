using Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Contracts;

public class LoginContract {

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Password]
    public string Password { get; set; } = string.Empty;
}
public class VerificationContract {
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Code(6)]
    public string Code { get; set; } = string.Empty;
} 
public record TokenContract(string Token);

