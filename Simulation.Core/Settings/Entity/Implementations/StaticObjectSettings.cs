using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;
public class StaticObjectSettings(LimitSettings percentArea, DisplaySettings displaySettings)
    : IEntitySettings
{
    public LimitSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplaySettings { get; } = displaySettings;
}
