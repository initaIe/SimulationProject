using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.BaseClasses;
public abstract class EntityBase(string displayMark) : IEntity
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public string DisplayMark { get; init; } = displayMark;
}