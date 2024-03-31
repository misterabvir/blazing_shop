using Application.Base.Repositories;
using Domain.Products;
using MediatR;
using Shared.Pagination;
using Shared.Results;

namespace Application.Products.GetAll;

public record ProductGetAllRequest(int Page, int PageSize) : IRequest<Result<Pagination<Product>>>;

public class ProductGetAllRequestHandler(IProductRepository productRepository)  : IRequestHandler<ProductGetAllRequest, Result<Pagination<Product>>>
{
    private readonly IProductRepository _productRepository = productRepository;
    
    public async Task<Result<Pagination<Product>>> Handle(ProductGetAllRequest request, CancellationToken cancellationToken)
    {
        return await _productRepository.GetAll(request.Page, request.PageSize);

    }
}
