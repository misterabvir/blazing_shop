using Application.Base.Repositories;
using Domain.Categories.ValueObjects;
using Domain.Products;
using Domain.Products.Entities;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Products.Commands.ProductCreate;

public record ProductCreateCommand(Guid CategoryId, string Title, string Description, string Image, List<ProductVariantCreateCommand> Variants) : IRequest<Result>;
public record ProductVariantCreateCommand(Guid VariantId, decimal Price);

public class ProductCreateCommandHandler(IProductRepository productRepository, IPublisher publisher) : IRequestHandler<ProductCreateCommand, Result>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly IPublisher _publisher = publisher;

    public async Task<Result> Handle(ProductCreateCommand request, CancellationToken cancellationToken)
    {
        var product = Product.Create(
            CategoryId.Create(request.CategoryId),
            Title.Create(request.Title),
            Description.Create(request.Description),
            Image.Create(request.Image));

        product.UpdateVariants(request.Variants.Select(v =>
            Variant.Create(
                PublishVariantId.Create(v.VariantId),
                product.Id,
                Price.Create(v.Price))));

        await _productRepository.Add(product);

        foreach(var domainEvent in product.DomainEvents)
            await _publisher.Publish(domainEvent, cancellationToken);

        product.ClearDomainEvents(); 
        return Result.Success();
    }
}
