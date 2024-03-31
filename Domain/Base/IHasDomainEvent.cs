namespace Domain.Base;

public interface IHasDomainEvent 
{ 
    IReadOnlyList<IDomainEvent> DomainEvents { get; }
    void ClearDomainEvents();
}