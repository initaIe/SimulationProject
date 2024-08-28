namespace Simulation.Core.Settings;

public class FieldSettings(FieldSizeSettings fieldSizeSettings, FieldDisplaySettings fieldDisplaySettings)
{
    public FieldSizeSettings FieldSizeSettings { get; init; } = fieldSizeSettings;
    public FieldDisplaySettings FieldDisplaySettings { get; init; } = fieldDisplaySettings;
}
