using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Settings.Entity.Attributes;
public class PreySettings(HashSet<IEntity> preys)
{
    public HashSet<IEntity> Preys { get; set; } = preys;
}
