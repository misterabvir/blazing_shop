using System.ComponentModel.DataAnnotations;

namespace Contracts.Products;

public class ProductVariantUpdateRequest
{
    public Guid PublishVariantId { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    public double Discount { get; set; }
}