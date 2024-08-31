namespace Simulation.Core.Entities.Interfaces;

public interface ICreature : IMovable, IFeedable
{
    int Health { get; }
}