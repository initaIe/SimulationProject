namespace Simulation.Core.Settings.Entity.Attributes;

public class SatietySettings(int minSatiety, int maxSatiety)
{
    public int MinSatiety { get; set; } = minSatiety;
    public int MaxSatiety { get; set; } = maxSatiety;
}
