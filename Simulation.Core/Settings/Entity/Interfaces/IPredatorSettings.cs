using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;

public interface IPredatorSettings : ICreatureSettings
{
    LimitSettings Damage { get; }
}
