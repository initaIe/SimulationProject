using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Implementations.EntityImplementations;

public class Food(string displayMark, int satiety) : EntityBase(displayMark), IEatable
{
    public int Satiety { get; init; } = satiety;
}