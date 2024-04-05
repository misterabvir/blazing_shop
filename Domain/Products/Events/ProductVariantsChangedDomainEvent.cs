using Domain.Base;
using Domain.Categories.ValueObjects;
using Domain.Products.ValueObjects;

namespace Domain.Products.Events;

public record ProductVariantsChangedDomainEvent(ProductId ProductId, CategoryId CategoryId, List<PublishVariantId> PublishVariantIds) : IDomainEvent;
