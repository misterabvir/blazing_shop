using System.ComponentModel.DataAnnotations;

namespace Contracts.Categories;

public class CategoryCreateRequest
{
    [Required]
    [MinLength(2)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(3)]
    public string Icon { get; set; } = string.Empty;
    public string Url => Title.Trim().Replace(" ", "-").ToLower();
    public List<PublishVariantCreateRequest> PublishVariants { get; set; } = [];
}
