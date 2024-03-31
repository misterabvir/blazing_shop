using Application.Base.Repositories;
using Domain.Categories;
using MediatR;
using Shared.Results;

namespace Application.Categories.GetAll;

public record CategoryGetAllQuery() : IRequest<Result<IEnumerable<Category>>>;

public class CategoryGetAllRequestHandler(ICategoryRepository categoryRepository ) : IRequestHandler<CategoryGetAllQuery, Result<IEnumerable<Category>>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    public async Task<Result<IEnumerable<Category>>> Handle(CategoryGetAllQuery request, CancellationToken cancellationToken)
    {
        var categories = await _categoryRepository.GetAll();    
        
        return categories.ToList();
    }
}
