using Simulation.Core.Implementations.EntityImplementations;

namespace Simulation.Core.Settings;

public class EntitiesSpeedSettings(
    int herbivoreMin = 1,
    int herbivoreMax = 2,

    int predatorMin = 2,
    int predatorMax = 3)
{
    public Dictionary<Type, (int minSpeed, int maxSpeed)> EntitiesSpeed { get; init; } = new()
    {
        { typeof(Herbivore), (herbivoreMin,herbivoreMax) },
        { typeof(Predator), (predatorMin,predatorMax) },
    };
}