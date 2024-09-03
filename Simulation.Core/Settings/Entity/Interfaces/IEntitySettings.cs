using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;
public interface IEntitySettings
{
    RangeSettings PercentArea { get; }
    DisplaySettings DisplayMark { get; }
}
