namespace Simulation.Core.Settings.Field;

public class DisplaySettings(string emptyCellDisplayMark = "\ud83d\udfe9")
{
    public string EmptyCellDisplayMark { get; init; } = emptyCellDisplayMark;
}