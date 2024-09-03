using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;
public class StaticObjectSettings(RangeSettings percentArea, DisplaySettings displayMark)
    : IEntitySettings
{
    public RangeSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplayMark { get; } = displayMark;
}
