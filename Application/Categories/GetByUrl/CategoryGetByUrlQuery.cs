using Application.Base.Repositories;
using Domain.Categories;
using Domain.Categories.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Categories.GetByUrl;

public record CategoryGetByUrlQuery(string Url) : IRequest<Result<Category>>;
public class CategoryGetByUrlQueryHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryGetByUrlQuery, Result<Category>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    
    
    public async Task<Result<Category>> Handle(CategoryGetByUrlQuery request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByUrl(Url.Create(request.Url));

        if(category is null)
        {
            return Error.NotFound("Category.GetByUrl.NotFount", $"Category with url \"{request.Url}\" not found");
        }

        return category;
    }
}
