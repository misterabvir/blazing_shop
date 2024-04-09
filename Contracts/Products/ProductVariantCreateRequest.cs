using System.ComponentModel.DataAnnotations;

namespace Contracts.Products;

public class ProductVariantCreateRequest
{
    public Guid PublishVariantId { get; set; }
    [Required]
    public decimal Price { get; set; }
}
