using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;

public class HerbivoreSettings(
    PercentAreaSettings percentArea,
    DisplaySettings displayMark,
    HealthSettings health,
    SpeedSettings speed,
    PreySettings preys)
    : ICreatureSettings
{
    public PercentAreaSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplayMark { get; } = displayMark;
    public HealthSettings Health { get; } = health;
    public SpeedSettings Speed { get; } = speed;
    public PreySettings Preys { get; } = preys;
}
