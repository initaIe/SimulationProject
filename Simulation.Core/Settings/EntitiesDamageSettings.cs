using Simulation.Core.Implementations.EntityImplementations;

namespace Simulation.Core.Settings;

public class EntitiesDamageSettings(
    int predatorMin = 4,
    int predatorMax = 6)
{
    public Dictionary<Type, (int minDamage, int maxDamage)> EntityDamage { get; init; } = new()
    {
        { typeof(Predator), (predatorMin,predatorMax) }
    };
}
