using Domain.Base;

namespace Domain.Categories.Events;

public record CategoryCreatedDomainEvent(Guid CategoryId, string Title, string Url) : IDomainEvent;

