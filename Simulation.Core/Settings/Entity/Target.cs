using Simulation.Core.Entities;

namespace Simulation.Core.Settings.Entity;
public class Target
{
    public Dictionary<Type, HashSet<Type>> EntitiesTargets { get; init; } = new()
    {
        { typeof(Predator), []},
        { typeof(Herbivore), []}
    };

    public Target()
    {
        EntitiesTargets[typeof(Predator)].Add(typeof(Food));
        EntitiesTargets[typeof(Predator)].Add(typeof(Herbivore));

        EntitiesTargets[typeof(Herbivore)].Add(typeof(Food));
    }
}
