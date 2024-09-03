using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;

public class FoodSettings(RangeSettings percentArea, DisplaySettings displayMark, RangeSettings satiety)
    : IFoodSettings
{
    public RangeSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplayMark { get; } = displayMark;
    public RangeSettings Satiety { get; } = satiety;
}
