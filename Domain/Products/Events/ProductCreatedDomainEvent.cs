using Domain.Base;

namespace Domain.Products.Events;

public record ProductCreatedDomainEvent(
    Guid ProductId,
    Guid CategoryId,
    string Title,
    string Description,
    string Image,
    decimal Price,
    DateTime CreatedAt
    ) : IDomainEvent;
