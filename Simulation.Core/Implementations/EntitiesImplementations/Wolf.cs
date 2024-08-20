using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntitiesInterfaces;

namespace Simulation.Core.Implementations.EntitiesImplementations;

public class Wolf : Entity, IPredator
{
    public int Speed { get; } = 2;
    public string DisplayMark { get; } = "🐺";

    public void Attack()
    {
        throw new NotImplementedException();
    }
    public void Move()
    {
        throw new NotImplementedException();
    }
}