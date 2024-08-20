using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntitiesInterfaces;

namespace Simulation.Core.Implementations.EntitiesImplementations;

public class Berries : Entity, IEatable
{
    public int Satiety { get; } = 2;
    public string DisplayMark { get; } = "🍓";
    public decimal SpawnRate { get; } = 0.075M;
}