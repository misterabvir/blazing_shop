using Shared.Attributes;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentications;

public class VerificationRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Code(6)]
    public string Code { get; set; } = string.Empty;
}

