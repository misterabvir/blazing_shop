using System.ComponentModel.DataAnnotations;

namespace Contracts.Authentications;

public class  UpdateAccountRequest
{
    [Required]
    [MinLength(3)]
    public string Username { get; set; } = string.Empty;
    [Required]
    [MinLength(3)]
    public string FirstName { get; set; } = string.Empty;
    
    [Required]
    [MinLength(3)]
    public string LastName { get; set; } = string.Empty;

    public string Avatar { get; set; } = string.Empty;
}