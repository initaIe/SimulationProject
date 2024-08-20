using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntitiesInterfaces;

namespace Simulation.Core.Implementations.EntitiesImplementations;

public class Rock : Entity, IStaticObject
{
    public decimal SpawnRate { get; } = 0.02M;
    public string DisplayMark { get; } = "⛰";
}