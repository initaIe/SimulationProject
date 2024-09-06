using Simulation.Core.Settings.Field;

namespace Simulation.Core.Settings;

public class FieldSettings(SizeSettings sizeSettings, CellDisplaySettings cellDisplaySettings)
{
    public SizeSettings SizeSettings { get; init; } = sizeSettings;
    public CellDisplaySettings cellDisplaySettings { get; init; } = cellDisplaySettings;
    public int GetFieldWidth() => SizeSettings.FieldWidth;
    public int GetFieldHeight() => SizeSettings.FieldHeight;
    public int GetCellsCount() => GetFieldHeight() * GetFieldWidth();
    public string GetEmptyCellDisplayMark() => cellDisplaySettings.EmptyCellDisplayMark;
}
