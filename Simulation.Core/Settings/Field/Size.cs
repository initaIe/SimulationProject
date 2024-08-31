namespace Simulation.Core.Settings.Field;

public class Size(int fieldWidth = 20, int fieldHeight = 35)
{
    public int FieldWidth { get; init; } = fieldWidth;
    public int FieldHeight { get; init; } = fieldHeight;
}

