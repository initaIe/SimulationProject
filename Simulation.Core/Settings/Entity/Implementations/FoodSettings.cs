using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings.Entity.Implementations;

public class FoodSettings(PercentAreaSettings percentArea, DisplaySettings displayMark, SatietySettings satiety)
    : IFoodSettings
{
    public PercentAreaSettings PercentArea { get; } = percentArea;
    public DisplaySettings DisplayMark { get; } = displayMark;
    public SatietySettings Satiety { get; } = satiety;
}
