using Simulation.Core.Entities;

namespace Simulation.Core.Settings.Entity;

public class Speed(
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