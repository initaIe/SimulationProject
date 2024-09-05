using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Entities.Base;
public abstract class EntityBase(string sprite) : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string Sprite { get; init; } = sprite;

    public override bool Equals(object? obj)
    {
        return obj is IEntity entity && Id == entity.Id;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }
}