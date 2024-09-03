using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;

public interface IPredatorSettings : ICreatureSettings
{
    RangeSettings Damage { get; }
}
