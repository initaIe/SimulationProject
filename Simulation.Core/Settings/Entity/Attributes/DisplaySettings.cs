namespace Simulation.Core.Settings.Entity.Attributes;

public class DisplaySettings(List<string> displayMarks)
{
    public List<string> DisplayMarks { get; set; } = displayMarks;
}
