using Domain.Base;

namespace Domain.Products.Events;

public record ProductTitleUpdatedDomainEvent(Guid ProductId, string Title) : IDomainEvent;
