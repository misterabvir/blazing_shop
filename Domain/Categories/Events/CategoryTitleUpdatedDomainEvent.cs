using Domain.Base;

namespace Domain.Categories.Events;

public record CategoryTitleUpdatedDomainEvent(Guid CategoryId, string Title) : IDomainEvent;
