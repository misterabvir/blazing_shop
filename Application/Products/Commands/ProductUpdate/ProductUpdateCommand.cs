using Application.Base.Repositories;
using Domain.Categories.ValueObjects;
using Domain.Errors;
using Domain.Products;
using Domain.Products.Entities;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Products.Commands.ProductUpdate;

public record ProductUpdateCommand(Guid Id, string Title, string Description, string Image, List<ProductUpdateVariantCommand> Variants) : IRequest<Result<Product>>;
public record ProductUpdateVariantCommand(Guid PublishVariantId, decimal Price, double Discount);


public class ProductUpdateCommandHandler(IProductRepository productRepository) : IRequestHandler<ProductUpdateCommand, Result<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Result<Product>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(ProductId.Create(request.Id));
        if (product is null) return Errors.Products.NotFound;

        product.Update(
            title: Title.Create(request.Title),
            description: Description.Create(request.Description),
            image: Image.Create(request.Image));

        product.UpdateVariants(request.Variants.Select(v=>Variant.Create(
            PublishVariantId.Create(v.PublishVariantId),
            product.Id,
            Price.Create(v.Price),
            Discount.Create(v.Discount))));


        await _productRepository.Update(product);

        return product;
    }
}