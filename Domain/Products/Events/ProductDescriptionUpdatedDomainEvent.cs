using Domain.Base;

namespace Domain.Products.Events;

public record ProductDescriptionUpdatedDomainEvent(Guid ProductId, string Description) : IDomainEvent;
