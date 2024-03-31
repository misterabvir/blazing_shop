using Application.Base.Repositories;
using Domain.Products;
using Domain.Products.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Products.GetById;


public record ProductGetByIdRequest(Guid ProductId) : IRequest<Result<Product>>;

public class ProductGetByIdRequestHandler(IProductRepository productRepository) : IRequestHandler<ProductGetByIdRequest, Result<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Result<Product>> Handle(ProductGetByIdRequest request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(ProductId.Create(request.ProductId));

        if (product is null)
        {
            return Error.NotFound("Product.GetById.NotFound", $"Product not found with id: {request.ProductId}");
        }

        return product;
    }
}

