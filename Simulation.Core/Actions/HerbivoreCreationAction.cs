using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Implementations;

namespace Simulation.Core.Actions;

public class HerbivoreCreationAction : EntityCreationActionBase
{
    private readonly Type _type = typeof(Herbivore);

    public override void Perform(IMap map, SimulationSettings simulationSettings)
    {
        var entityCountLimits = GetLimitsOfEntityInNumbers(_type, simulationSettings);

        var entityRandomMaxLimitCount = GetRandomValueInLimits(entityCountLimits);

        while (map.GetCountByType(_type) < entityRandomMaxLimitCount)
        {
            var newStaticObject = CreateEntity(simulationSettings.Entities);
            SpawnEntity(map, simulationSettings, newStaticObject);
        }
    }

    protected override IEntity CreateEntity(EntitiesSettings entitiesSettings)
    {
        var herbivoreSettings = (HerbivoreSettings)entitiesSettings.GetEntitySettingsByType(_type);
        var sprite = GetRandomValue(herbivoreSettings.DisplaySettings.Sprites);
        var speed = GetRandomValueInLimits(herbivoreSettings.Speed);
        var health = GetRandomValueInLimits(herbivoreSettings.Health);

        return new Herbivore(sprite, speed, health);
    }
}
