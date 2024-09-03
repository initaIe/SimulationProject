namespace Simulation.Core.Settings.Entity.Attributes;
public class RangeSettings(int min, int max)
{
    public int Min { get; set; } = min;
    public int Max { get; set; } = max;
}