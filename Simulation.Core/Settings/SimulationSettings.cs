namespace Simulation.Core.Settings;

public class SimulationSettings(EntitiesSettings entities, FieldSettings field)
{
    public EntitiesSettings Entities { get; init; } = entities;
    public FieldSettings Field { get; init; } = field;
    public int GetFieldWidth() => Field.Size.FieldWidth;
    public int GetFieldHeight() => Field.Size.FieldHeight;
    public int GetCellsCount() => GetFieldHeight() * GetFieldWidth();
    public string GetEmptyCellDisplayMark() => Field.Display.EmptyCellDisplayMark;
}
