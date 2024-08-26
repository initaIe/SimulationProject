namespace Simulation.Core.Interfaces.EntityInterfaces;

public interface ICreature : IMovable, IFeedable
{
    int Health { get; }
}