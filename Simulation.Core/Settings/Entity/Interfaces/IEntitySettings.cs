using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;
public interface IEntitySettings
{
    PercentAreaSettings PercentArea { get; }
    DisplaySettings DisplayMark { get; }
}
