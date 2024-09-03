using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;
public class PredatorSettings(
    RangeSettings percentArea,
    DisplaySettings displayMark,
    RangeSettings health,
    RangeSettings speed,
    PreySettings preys,
    RangeSettings damage)
    : IPredatorSettings
{
    public RangeSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplayMark { get; } = displayMark;
    public RangeSettings Health { get; } = health;
    public RangeSettings Speed { get; } = speed;
    public PreySettings Preys { get; } = preys;
    public RangeSettings Damage { get; } = damage;
}
