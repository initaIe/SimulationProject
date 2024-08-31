using Simulation.Core.Settings.Field;

namespace Simulation.Core.Settings;

public class FieldSettings(Size size, Display display)
{
    public Size Size { get; init; } = size;
    public Display Display { get; init; } = display;
}
