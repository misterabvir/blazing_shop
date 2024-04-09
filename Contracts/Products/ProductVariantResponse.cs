namespace Contracts.Products;

public class ProductVariantResponse
{
    public Guid Id { get; set; }
    public Guid PublishVariantId { get; set; }
    public decimal Price { get; set; }
    public double Discount { get; set; }
    public decimal DiscountedPrice => Math.Round(Price - (Price * (decimal)Discount / 100), 2);
}
