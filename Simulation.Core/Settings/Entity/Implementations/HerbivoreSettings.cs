using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;

public class HerbivoreSettings(
    LimitSettings percentArea,
    DisplaySettings displaySettings,
    LimitSettings health,
    LimitSettings speed,
    PreySettings preys)
    : ICreatureSettings
{
    public LimitSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplaySettings { get; } = displaySettings;
    public LimitSettings Health { get; } = health;
    public LimitSettings Speed { get; } = speed;
    public PreySettings Preys { get; } = preys;
}
