using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntitiesInterfaces;

namespace Simulation.Core.Implementations.EntitiesImplementations;

public class Sheep : Entity, IHerbivore
{
    public int Speed { get; }
    public string DisplayMark { get; } = "🐑";
    public void Eat()
    {
        throw new NotImplementedException();
    }

    public void Move()
    {
        throw new NotImplementedException();
    }
}