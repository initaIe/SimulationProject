using Simulation.Core.Entities;

namespace Simulation.Core.Settings.Entity;

public class Display(
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
