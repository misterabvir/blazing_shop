using Application.Base.Repositories;
using Domain.Categories.ValueObjects;
using Domain.Errors;
using Domain.Products;
using Domain.Products.ValueObjects;
using Domain.Shared.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Products.Commands.ProductUpdate;

public record ProductUpdateCommand(Guid Id, string Title, string Description, string Image, decimal Price, List<Guid> CategoryIds) : IRequest<Result<Product>>;

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

        // TODO Update variants


        await _productRepository.Update(product);

        return product;
    }
}