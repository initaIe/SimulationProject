using Simulation.Core.Entities;
using Simulation.Core.Settings.Entity.Implementations;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Settings;

public class EntitiesSettings(
    StaticObjectSettings staticObjectSettings,
    FoodSettings foodSettings,
    HerbivoreSettings herbivoreSettings,
    PredatorSettings predatorSettings)
{
    private readonly Dictionary<Type, IEntitySettings> _entitySettings = new()
    {
        { typeof(StaticObject), staticObjectSettings },
        { typeof(Food), foodSettings },
        { typeof(Herbivore), herbivoreSettings },
        { typeof(Predator), predatorSettings }
    };

    public IEntitySettings GetEntitySettingsByType(Type type)
    {
        if (_entitySettings.TryGetValue(type, out var settings))
        {
            return settings;
        }
        throw new ArgumentException($"Settings for type {type.Name} not found.");
    }
}