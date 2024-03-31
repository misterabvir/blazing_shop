using Domain.Base;

namespace Domain.Products.Events;

public record ProductImageUpdatedDomainEvent(Guid ProductId, string Image) : IDomainEvent;
