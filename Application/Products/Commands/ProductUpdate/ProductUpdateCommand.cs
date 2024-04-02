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

public class ProductUpdateCommandHandler(IProductRepository productRepository, ICategoryRepository categoryRepository) : IRequestHandler<ProductUpdateCommand, Result<Product>>
{
    private readonly IProductRepository _productRepository = productRepository;
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    
    public async Task<Result<Product>> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
    {
        var product = await _productRepository.GetById(ProductId.Create(request.Id));
        if(product is null) return Errors.Products.NotFound;
        
        var result = product.UpdateTitle(Title.Create(request.Title));
        if (result.IsFailure) return result.Errors;
        
        result = product.UpdateDescription(Description.Create(request.Description));
        if (result.IsFailure) return result.Errors;

        result = product.UpdateImage(Image.Create(request.Image));
        if (result.IsFailure) return result.Errors;

        result = product.UpdatePrice(Price.Create(request.Price));
        if (result.IsFailure) return result.Errors;

        var categories = await _categoryRepository.GetCategoriesByIds(request.CategoryIds.Select(CategoryId.Create));
        result = product.UpdateCategories(categories);
        if (result.IsFailure) return result.Errors;

        await _productRepository.Update(product);

        return product;
    }
}