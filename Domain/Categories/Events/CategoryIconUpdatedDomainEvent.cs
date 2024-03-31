using Domain.Base;

namespace Domain.Categories.Events;

public record CategoryIconUpdatedDomainEvent(Guid CategoryId, string Icon) : IDomainEvent;
