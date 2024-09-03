using Simulation.Core.Settings.Field;

namespace Simulation.Core.Settings;

public class FieldSettings(SizeSettings size, DisplaySettings display)
{
    public SizeSettings Size { get; init; } = size;
    public DisplaySettings Display { get; init; } = display;
    public int GetFieldWidth() => Size.FieldWidth;
    public int GetFieldHeight() => Size.FieldHeight;
    public int GetCellsCount() => GetFieldHeight() * GetFieldWidth();
    public string GetEmptyCellDisplayMark() => Display.EmptyCellDisplayMark;
}
