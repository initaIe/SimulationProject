using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;

public interface ICreatureSettings : IEntitySettings
{
    LimitSettings Health { get; }
    LimitSettings Speed { get; }
    PreySettings Preys { get; }
}
