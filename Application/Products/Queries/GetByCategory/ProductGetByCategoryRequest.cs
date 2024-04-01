using Application.Base.Repositories;
using Domain.Categories.ValueObjects;
using Domain.Products;
using MediatR;
using Shared.Pagination;
using Shared.Results;

namespace Application.Products.Queries.GetByCategory;

public record ProductGetByCategoryRequest(Guid CategoryId, int Page, int PageSize) : IRequest<Result<Pagination<Product>>>;

public class ProductGetByCategoryRequestHandler(IProductRepository productRepository) : IRequestHandler<ProductGetByCategoryRequest, Result<Pagination<Product>>>
{
    private readonly IProductRepository _productRepository = productRepository;

    public async Task<Result<Pagination<Product>>> Handle(ProductGetByCategoryRequest request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetByCategory(CategoryId.Create(request.CategoryId), request.Page, request.PageSize);
    }
}

