using Domain.Base;

namespace Domain.Products.Events;

public record ProductPriceUpdatedDomainEvent(Guid ProductId, decimal Price, decimal OriginalPrice) : IDomainEvent;