namespace Simulation.Core.Settings.Entity.Attributes;

public class PercentAreaSettings(int minPercentArea, int maxPercentArea)
{
    public int MinPercentArea { get; set; } = minPercentArea;
    public int MaxPercentArea { get; set; } = maxPercentArea;
}
