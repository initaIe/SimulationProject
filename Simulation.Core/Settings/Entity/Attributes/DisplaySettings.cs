namespace Simulation.Core.Settings.Entity.Attributes;

public class DisplaySettings(HashSet<string> displayMarks)
{
    public HashSet<string> DisplayMarks { get; set; } = displayMarks;
}