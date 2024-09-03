using Simulation.Core.Settings.Field;

namespace Simulation.Core.Settings;

public class FieldSettings(SizeSettings sizeSettings, DisplaySettings displaySettings)
{
    public SizeSettings SizeSettings { get; init; } = sizeSettings;
    public DisplaySettings DisplaySettings { get; init; } = displaySettings;
    public int GetFieldWidth() => SizeSettings.FieldWidth;
    public int GetFieldHeight() => SizeSettings.FieldHeight;
    public int GetCellsCount() => GetFieldHeight() * GetFieldWidth();
    public string GetEmptyCellDisplayMark() => DisplaySettings.EmptyCellDisplayMark;
}
