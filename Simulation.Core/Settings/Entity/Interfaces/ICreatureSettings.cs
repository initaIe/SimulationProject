using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;

public interface ICreatureSettings : IEntitySettings
{
    HealthSettings Health { get; }
    SpeedSettings Speed { get; }
    PreySettings Preys { get; }
}
