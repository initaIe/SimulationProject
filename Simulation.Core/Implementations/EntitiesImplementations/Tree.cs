using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntitiesInterfaces;

namespace Simulation.Core.Implementations.EntitiesImplementations;

public class Tree : Entity, IStaticObject
{
    public string DisplayMark { get; } = "🌳";
}