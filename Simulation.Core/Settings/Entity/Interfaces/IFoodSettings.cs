using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Settings.Entity.Interfaces;

public interface IFoodSettings : IEntitySettings
{
    SatietySettings Satiety { get; }
}