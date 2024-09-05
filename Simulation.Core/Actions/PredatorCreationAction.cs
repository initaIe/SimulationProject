using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Implementations;

namespace Simulation.Core.Actions;
public class PredatorCreationAction : EntityCreationActionBase
{
    private readonly Type _type = typeof(Predator);

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
        var predatorSettings = (PredatorSettings)entitiesSettings.GetEntitySettingsByType(_type);
        var sprite = GetRandomValue(predatorSettings.DisplaySettings.Sprites);
        var speed = GetRandomValueInLimits(predatorSettings.Speed);
        var health = GetRandomValueInLimits(predatorSettings.Health);
        var damage = GetRandomValueInLimits(predatorSettings.Damage);

        return new Predator(sprite, speed, health, damage);
    }
}
