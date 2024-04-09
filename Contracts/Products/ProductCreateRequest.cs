using System.ComponentModel.DataAnnotations;

namespace Contracts.Products;

public class ProductCreateRequest
{
    public Guid CategoryId { get; set; }
    [Required]
    [MinLength(3)]
    public string Title { get; set; } = string.Empty;
    [Required]
    [MinLength(3)]
    public string Description { get; set; } = string.Empty;
    [Required]
    [MinLength(3)]
    public string Image { get; set; } = string.Empty;

    public List<ProductVariantCreateRequest> Variants { get; set; } = [];
}
