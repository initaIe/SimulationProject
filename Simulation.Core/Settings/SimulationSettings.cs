namespace Simulation.Core.Settings;

public class SimulationSettings(EntitiesSettings entitiesSettings, FieldSettings fieldSettings)
{
    public EntitiesSettings EntitiesSettings { get; init; } = entitiesSettings;
    public FieldSettings FieldSettings { get; init; } = fieldSettings;
}
