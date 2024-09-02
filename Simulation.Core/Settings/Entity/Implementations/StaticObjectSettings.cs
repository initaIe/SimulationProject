using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;
public class StaticObjectSettings(PercentAreaSettings percentArea, DisplaySettings displayMark)
    : IEntitySettings
{
    public PercentAreaSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplayMark { get; } = displayMark;
}
