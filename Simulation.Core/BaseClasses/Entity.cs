namespace Simulation.Core.BaseClasses;
public abstract class Entity
{
    public Guid Id { get; init; } = Guid.NewGuid();
}