namespace Simulation.Core.Settings.Entity.Attributes;
public class PreySettings(HashSet<Type> preys)
{
    public HashSet<Type> Preys { get; set; } = preys;
}
