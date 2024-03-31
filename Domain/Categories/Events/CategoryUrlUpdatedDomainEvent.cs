using Domain.Base;

namespace Domain.Categories;

public record CategoryUrlUpdatedDomainEvent(Guid CategoryId, string Url) : IDomainEvent;
