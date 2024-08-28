using Simulation.Core.Implementations.EntityImplementations;

namespace Simulation.Core.Settings.Entity;

public class EntitiesDisplaySettings(
    string foodDisplayMark = "🌿",
    string predatorDisplayMark = "🐺",
    string herbivoreDisplayMark = "🐑",
    string staticObjectDisplayMark = "🌳"
    )
{
    public Dictionary<Type, string> EntitiesDisplayMarks { get; init; } = new()
    {
        { typeof(Food),  foodDisplayMark},
        { typeof(Predator),  predatorDisplayMark},
        { typeof(Herbivore),  herbivoreDisplayMark},
        { typeof(StaticObject), staticObjectDisplayMark }
    };
}
