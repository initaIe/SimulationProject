using Simulation.Core.Entities;

namespace Simulation.Core.Settings.Entity;

public class Satiety(
    int foodMin = 2,
    int foodMax = 4
    )
{
    public Dictionary<Type, (int minSatiety, int maxSatiety)> EntitiesSatiety { get; init; } = new()
    {
        { typeof(Food), (foodMin,foodMax) }
    };
}
