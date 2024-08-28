using Simulation.Core.Implementations.EntityImplementations;

namespace Simulation.Core.Settings;

public class EntitiesSatietySettings(
    int foodMin = 2,
    int foodMax = 4
    )
{
    public Dictionary<Type, (int minSatiety, int maxSatiety)> EntitiesSatiety { get; init; } = new()
    {
        { typeof(Food), (foodMin,foodMax) }
    };
}
