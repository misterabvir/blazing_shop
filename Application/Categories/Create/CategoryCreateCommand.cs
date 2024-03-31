using Application.Base.Repositories;
using Domain.Categories;
using Domain.Categories.ValueObjects;
using Domain.Shared.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Categories.Create;

public record CategoryCreateCommand(string Title, string Icon, string Url):
    IRequest<Result<Category>>;

public class CategoryCreateCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryCreateCommand, Result<Category>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;


    public async Task<Result<Category>> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var title = Title.Create(request.Title);
        var icon = Icon.Create(request.Icon);
        var url = Url.Create(request.Url);

        var result = Category.Create(title, icon, url);
        if(result.IsSuccess)
            result = await _categoryRepository.Add(result.Value!);
        return result;
    }
}
