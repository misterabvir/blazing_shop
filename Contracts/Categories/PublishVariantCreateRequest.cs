using System.ComponentModel.DataAnnotations;

namespace Contracts.Categories;

public class PublishVariantCreateRequest
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(3)]
    public string Icon { get; set; } = string.Empty;
    public string Url  => Title.Trim().Replace(" ", "-").ToLower();
}