using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.EntitySettings.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;

public interface IPredatorSettings : ICreatureSettings
{
    DamageSettings Damage { get; }
}
