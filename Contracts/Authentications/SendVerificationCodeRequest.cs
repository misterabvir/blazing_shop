using Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentications;

public record SendVerificationCodeRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
}

public record ConfirmVerificationCodeRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [Code(6)]
    public string Code { get; set; } = string.Empty;
}

public record ResetPasswordRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;
    [Required]
    [Password]
    public string Password { get; set; } = string.Empty;

    [Required]
    [Password]
    [MatchProperty(nameof(Password))]
    public string ConfirmPassword { get; set; } = string.Empty;
}