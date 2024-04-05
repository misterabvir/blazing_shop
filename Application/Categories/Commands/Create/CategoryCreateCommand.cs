using Application.Base.Repositories;
using Domain.Categories;
using Domain.Categories.Entities;
using Domain.Categories.ValueObjects;
using Domain.Shared.ValueObjects;
using MediatR;
using Shared.Results;

namespace Application.Categories.Commands.Create;

public record CategoryCreateCommand(string Title, string Icon, string Url, IEnumerable<CategoryPublishVariantItem> Variants) :
    IRequest<Result<Category>>;

public record CategoryPublishVariantItem(string Title, string Icon, string Url);


public class CategoryCreateCommandHandler(ICategoryRepository categoryRepository) : IRequestHandler<CategoryCreateCommand, Result<Category>>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;


    public async Task<Result<Category>> Handle(CategoryCreateCommand request, CancellationToken cancellationToken)
    {
        var title = Title.Create(request.Title);
        var icon = Icon.Create(request.Icon);
        var url = Url.Create(request.Url);

        var category = Category.Create(title, icon, url);
        category.AddPublishVariants(request.Variants.Select(v => PublishVariant.Create(category.Id, Title.Create(v.Title), Icon.Create(v.Icon), Url.Create(v.Url))));

        await _categoryRepository.Add(category);

        return category;
    }
}
