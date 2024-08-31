using Simulation.Core.Entities;

namespace Simulation.Core.Settings.Entity;

public class Damage(
    int predatorMin = 4,
    int predatorMax = 6)
{
    public Dictionary<Type, (int minDamage, int maxDamage)> EntitiesDamage { get; init; } = new()
    {
        { typeof(Predator), (predatorMin,predatorMax) }
    };
}
