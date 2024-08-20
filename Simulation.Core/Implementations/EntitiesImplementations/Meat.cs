using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntitiesInterfaces;

namespace Simulation.Core.Implementations.EntitiesImplementations;

public class Meat : Entity, IEatable
{
    public int Satiety { get; } = 1;
    public decimal SpawnRate { get; } = 0.01M;
    public string DisplayMark { get; } = "🍖";
}