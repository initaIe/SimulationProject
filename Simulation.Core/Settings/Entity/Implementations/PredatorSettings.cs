using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;
public class PredatorSettings(
    PercentAreaSettings percentArea,
    DisplaySettings displayMark,
    HealthSettings health,
    SpeedSettings speed,
    PreySettings preys,
    DamageSettings damage)
    : IPredatorSettings
{
    public PercentAreaSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplayMark { get; } = displayMark;
    public HealthSettings Health { get; } = health;
    public SpeedSettings Speed { get; } = speed;
    public PreySettings Preys { get; } = preys;
    public DamageSettings Damage { get; } = damage;
}
