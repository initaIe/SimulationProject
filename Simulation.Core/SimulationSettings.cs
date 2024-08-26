namespace Simulation.Core;

public class SimulationSettings
{
    public EntitiesSettings EntitiesSettings { get; set; } = new();
    public FieldSettings FieldSettings { get; set; } = new();
}
