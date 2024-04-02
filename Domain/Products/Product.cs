using Domain.Base;
using Domain.Products.Events;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using Shared.Results;

namespace Domain.Products;

public class Product : Entity<ProductId>
{
    public Title Title { get; private set; } = null!;
    public Description Description { get; private set; } = null!;
    public Image Image { get; private set; } = null!;
    public Price Price { get; private set; } = null!;
    public Price OriginalPrice { get; private set; } = null!;
    public Date CreatedAt { get; private set; } = null!;
    public Date UpdatedAt { get; private set; } = null!;

    private Product() { }

    private Product(ProductId id, Title title, Description description, Image image, Price price)
    {
        Id = id;
        Title = title;
        Description = description;
        Image = image;
        OriginalPrice = price;
        Price = price;
        CreatedAt = Date.Now;
        UpdatedAt = Date.Now;
    }

    public static Result<Product> Create(
        Title title,
        Description description,
        Image image,
        Price price)
    {
        var product = new Product(ProductId.CreateUnique(),
                 title,
                 description,
                 image,
                 price);

        product.RaiseDomainEvent(new ProductCreatedDomainEvent(
                product.Id.Value,
                product.Title.Value,
                product.Description.Value,
                product.Image.Value,
                product.Price.Value,
                product.CreatedAt.Value
            ));

        return product;
    }

    public Result UpdateTitle(Title title)
    {
        if (Title != title)
        {
            Title = title;
            UpdatedAt = Date.Now;
            RaiseDomainEvent(new ProductTitleUpdatedDomainEvent(Id.Value, Title.Value));
            return Result.Success();
        }
        return Error.BadRequest("Domain.Product.UpdateName", "Product has same name");
    }


    public Result UpdateDescription(Description description)
    {
        if (Description != description)
        {
            Description = description;
            UpdatedAt = Date.Now;
            RaiseDomainEvent(new ProductDescriptionUpdatedDomainEvent(Id.Value, Description.Value));
            return Result.Success();
        }
        return Error.BadRequest("Domain.Product.UpdateDescription", "Product has same description");
    }

    public Result UpdateImage(Image image)
    {
        if (Image != image)
        {
            Image = image;
            UpdatedAt = Date.Now;
            RaiseDomainEvent(new ProductImageUpdatedDomainEvent(Id.Value, Image.Value));
            return Result.Success();
        }
        return Error.BadRequest("Domain.Product.UpdateImage", "Product has same image");
    }

    public Result UpdatePrice(Price price)
    {
        if (Price != price && OriginalPrice > price)
        {
            Price = price;
            UpdatedAt = Date.Now;
            RaiseDomainEvent(new ProductPriceUpdatedDomainEvent(Id.Value, Price.Value, OriginalPrice.Value));
            return Result.Success();
        }
        return Error.BadRequest("Domain.Product.UpdatePrice", "Product has same price or new price is greater than original price");
    }
}
