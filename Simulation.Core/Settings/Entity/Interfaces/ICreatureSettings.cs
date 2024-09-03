using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;

public interface ICreatureSettings : IEntitySettings
{
    RangeSettings Health { get; }
    RangeSettings Speed { get; }
    PreySettings Preys { get; }
}
