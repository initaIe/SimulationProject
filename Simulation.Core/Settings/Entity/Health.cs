using Simulation.Core.Entities;

namespace Simulation.Core.Settings.Entity;

public class Health(
    int herbivoreMin = 5,
    int herbivoreMax = 10,

    int predatorMin = 10,
    int predatorMax = 15)
{
    public Dictionary<Type, (int minHealth, int maxHealth)> EntitiesHealth { get; init; } = new()
    {
        { typeof(Herbivore), (herbivoreMin,herbivoreMax) },
        { typeof(Predator), (predatorMin,predatorMax) },
    };
}
