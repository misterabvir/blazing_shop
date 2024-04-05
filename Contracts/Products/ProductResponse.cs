using Contracts.Categories;
using System.ComponentModel.DataAnnotations;

namespace Contracts.Products;

public class ProductResponse
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public IEnumerable<ProductVariantResponse> Variants { get; set; } = [];
}

public class ProductVariantResponse
{
    public Guid Id { get; set; }
    public Guid PublishVariantId { get; set; }
    public decimal Price { get; set; }
    public double Discount { get; set; }
}



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

public class ProductVariantCreateRequest
{
    public Guid PublishVariantId { get; set; }
    [Required]
    public decimal Price { get; set; }
}

public class ProductUpdateRequest
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public List<Guid> PublishVariantId { get; set; } = [];
}