using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;
public interface IEntitySettings
{
    LimitSettings PercentArea { get; }
    DisplaySettings DisplaySettings { get; }
}
