using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Implementations;

namespace Simulation.Core.Actions;
public class FoodCreationAction : EntityCreationActionBase
{
    private readonly Type _type = typeof(Food);

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
        var foodSettings = (FoodSettings)entitiesSettings.GetEntitySettingsByType(_type);
        var sprite = GetRandomValue(foodSettings.DisplaySettings.Sprites);
        var satiety = GetRandomValueInLimits(foodSettings.Satiety);

        return new Food(sprite, satiety);
    }
}
