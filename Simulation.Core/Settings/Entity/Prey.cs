using Simulation.Core.Entities;

namespace Simulation.Core.Settings.Entity;
public class Prey
{
    public Dictionary<Type, HashSet<Type>> PreyEntities { get; init; } = new()
    {
        { typeof(Predator), []},
        { typeof(Herbivore), []}
    };

    public Prey()
    {
        PreyEntities[typeof(Predator)].Add(typeof(Food));
        PreyEntities[typeof(Predator)].Add(typeof(Herbivore));

        PreyEntities[typeof(Herbivore)].Add(typeof(Food));
    }
}
