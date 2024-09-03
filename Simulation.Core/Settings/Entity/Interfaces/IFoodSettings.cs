using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;

public interface IFoodSettings : IEntitySettings
{
    LimitSettings Satiety { get; }
}