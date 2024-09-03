using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Attributes;

namespace Simulation.Core.Actions;
public class StaticObjectCreationAction : EntityCreationActionBase
{
    private readonly Type _type = typeof(StaticObject);
    public override void Perform(IMap map, SimulationSettings simulationSettings)
    {
        var entityCurrentCount = map.GetCountByType(_type);

        var entityCountLimits = GetLimitsOfObjectInNumbers(_type, simulationSettings);

        var entityRandomMaxLimitCount = GetRandomValueInLimits(entityCountLimits);

        while (entityCurrentCount < entityRandomMaxLimitCount)
        {
            var newStaticObject = CreateEntity(simulationSettings.Entities);
            SpawnEntity(map, simulationSettings, newStaticObject);

            entityCurrentCount = map.GetCountByType(_type);
        }
    }

    protected override IEntity CreateEntity(EntitiesSettings entitiesSettings)
    {
        var entitySettings = entitiesSettings.GetEntitySettingsByType(_type);
        int max = entitySettings.DisplayMark.DisplayMarks.Count;
        int randomIndex = Random.Next(0, max);
        string displayMark = entitySettings.DisplayMark.DisplayMarks.ElementAt(randomIndex);

        return new StaticObject(displayMark);
    }

    protected override void SpawnEntity(IMap map, SimulationSettings simulationSettings, IEntity entity)
    {
        if (!TryGetRandomEmptyLocation(out var rndLocation)) return;

        map.Add(rndLocation, entity);
    }
}
