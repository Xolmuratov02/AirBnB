namespace AirBnB.Domain.Common.Entities;

public abstract class Entity : IEntity
{
    public Guid Id { get; set; }
}