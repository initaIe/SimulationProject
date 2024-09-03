namespace Simulation.Core.Settings;

public class SimulationSettings(EntitiesSettings entities, FieldSettings field)
{
    public EntitiesSettings Entities { get; init; } = entities;
    public FieldSettings Field { get; init; } = field;
}
