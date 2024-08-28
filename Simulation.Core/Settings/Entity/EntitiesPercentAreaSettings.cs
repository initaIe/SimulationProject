using Simulation.Core.Implementations.EntityImplementations;

namespace Simulation.Core.Settings.Entity;

public class EntitiesPercentAreaSettings(
    int staticObjectMin = 10,
    int staticObjectMax = 20,

    int herbivoreMin = 5,
    int herbivoreMax = 10,

    int predatorMin = 2,
    int predatorMax = 4,

    int foodMin = 10,
    int foodMax = 15)
{
    public Dictionary<Type, (int minPercentArea, int maxPercentArea)> EntityAreaPercentage { get; init; } = new()
    {
        { typeof(StaticObject), (staticObjectMin, staticObjectMax) },
        { typeof(Herbivore),  (herbivoreMin, herbivoreMax)},
        { typeof(Predator),  (predatorMin, predatorMax)},
        { typeof(Food),  (foodMin, foodMax)}
    };
}
