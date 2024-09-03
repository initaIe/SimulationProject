using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;

namespace Simulation.Core.Actions;
public class StaticObjectCreationAction : EntityCreationActionBase
{
    private readonly Type _type = typeof(StaticObject);
    public override void Perform(IMap map, SimulationSettings simulationSettings)
    {
        var currentCount = map.GetCountByType(_type);
        var randomQuantityInRange = GetRandomQuantityInRange(_type, map, simulationSettings);

        while (currentCount < randomQuantityInRange)
        {
            var newEntity = CreateEntity(map, simulationSettings);
            SpawnEntity(map, simulationSettings, newEntity);

            currentCount = map.GetCountByType(_type);
        }
    }

    public override IEntity CreateEntity(IMap map, SimulationSettings simulationSettings)
    {
        var entitySettings = GetEntitySettings(_type, simulationSettings);
        int max = entitySettings.DisplayMark.DisplayMarks.Count;
        int randomIndex = Rnd.Next(0, max);
        string displayMark = entitySettings.DisplayMark.DisplayMarks[randomIndex];

        return new StaticObject(displayMark);
    }

    public void SpawnEntity(IMap map, SimulationSettings simulationSettings, IEntity entity)
    {
        if (!TryGetRandomEmptyLocation(map, simulationSettings, out var rndLocation)) return;

        map.Add(rndLocation, entity);
    }
}
