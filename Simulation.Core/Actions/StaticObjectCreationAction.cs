﻿using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Attributes;
using Simulation.Core.Settings.Entity.Implementations;

namespace Simulation.Core.Actions;
public class StaticObjectCreationAction : EntityCreationActionBase
{
    private readonly Type _type = typeof(StaticObject);

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
        var staticObjectSettings = (StaticObjectSettings)entitiesSettings.GetEntitySettingsByType(_type);

        var sprite = GetRandomValue(staticObjectSettings.DisplaySettings.Sprites);

        return new StaticObject(sprite);
    }
}
