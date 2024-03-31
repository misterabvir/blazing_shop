using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Base;

public abstract class Entity<T> : IEquatable<Entity<T>>, IHasDomainEvent
    where T : ValueObject
{
    public T Id { get; protected set; } = null!;

    public bool Equals(Entity<T>? other) => other is not null && Id == other.Id;
    public override bool Equals(object? obj) => obj is not null && Equals(obj as Entity<T>);
    public override int GetHashCode() => Id.GetHashCode();
    public static bool operator == (Entity<T>? left, Entity<T>? right) => left is not null && left.Equals(right);
    public static bool operator != (Entity<T>? left, Entity<T>? right) => !(left == right);

    protected readonly List<IDomainEvent> _domainEvents = [];
    [NotMapped]
    public IReadOnlyList<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();
    protected void RaiseDomainEvent(IDomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    public void ClearDomainEvents() => _domainEvents.Clear();

}

