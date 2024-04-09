using Application.Base.Repositories;
using Domain.Categories.ValueObjects;
using Domain.Products;
using MediatR;
using Shared.Pagination;
using Shared.Results;

namespace Application.Products.Queries.GetByVariant;

public record ProductGetByVariantRequest(Guid VariantId, int Page, int PageSize) : IRequest<Result<Pagination<Product>>>;

public class ProductGetByVariantRequestHandler(IProductRepository productRepository) : IRequestHandler<ProductGetByVariantRequest, Result<Pagination<Product>>>
{
    private readonly IProductRepository _productRepository = productRepository;
    
    public async Task<Result<Pagination<Product>>> Handle(ProductGetByVariantRequest request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByVariant(PublishVariantId.Create(request.VariantId), request.Page, request.PageSize);
    }
}

