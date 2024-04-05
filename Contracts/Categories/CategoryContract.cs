using System.ComponentModel.DataAnnotations;

namespace Contracts.Categories;

public class CategoryContract
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
    public List<PublishVariantContract> PublishVariants { get; set; } = [];
}

public class PublishVariantContract
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Icon { get; set; } = string.Empty;
    public string Url { get; set; } = string.Empty;
}

public class CategoryCreateRequest
{
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(3)]
    public string Icon { get; set; } = string.Empty;
    public string Url => Title.Trim().Replace(" ", "-").ToLower();
    public List<PublishVariantCreateRequest> PublishVariants { get; set; } = [];
}

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