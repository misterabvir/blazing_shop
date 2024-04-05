using Application.Base.Repositories;
using Domain.Products.Events;
using MediatR;

namespace Application.Products.Events;

internal class ProductVariantsChangedDomainEventHandler(ICategoryRepository categoryRepository) : INotificationHandler<ProductVariantsChangedDomainEvent>
{
    private readonly ICategoryRepository _categoryRepository = categoryRepository;
    
    public async Task Handle(ProductVariantsChangedDomainEvent notification, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetById(notification.CategoryId);
        if(category is null)
        {
            return;
        }
        
        category.AddProductIdInVariants(notification.ProductId, notification.PublishVariantIds);
        await _categoryRepository.Update(category);   
        
    }
}
