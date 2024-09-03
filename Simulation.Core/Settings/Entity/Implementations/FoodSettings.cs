using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;

public class FoodSettings(LimitSettings percentArea, DisplaySettings displaySettings, LimitSettings satiety)
    : IFoodSettings
{
    public LimitSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplaySettings { get; } = displaySettings;
    public LimitSettings Satiety { get; } = satiety;
}
