namespace Domain.Base;

public abstract class AggregateRoot<T> : Entity<T>
    where T : ValueObject
{
}