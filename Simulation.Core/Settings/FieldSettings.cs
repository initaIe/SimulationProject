using Simulation.Core.Settings.Field;

namespace Simulation.Core.Settings;

public class FieldSettings(FieldSizeSettings fieldSizeSettings, FieldDisplaySettings fieldDisplaySettings)
{
    public FieldSizeSettings FieldSizeSettings { get; init; } = fieldSizeSettings;
    public FieldDisplaySettings FieldDisplaySettings { get; init; } = fieldDisplaySettings;
    public int GetCountOfCells() => FieldSizeSettings.FieldHeight * FieldSizeSettings.FieldWidth;
}
