using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;
using System.Diagnostics.CodeAnalysis;

namespace Simulation.Core.Actions;

public abstract class EntityCreationActionBase : IAction
{
    protected readonly Random Rnd = new();

    public abstract void Perform(IMap map, SimulationSettings simulationSettings);

    public abstract IEntity CreateEntity(IMap map, SimulationSettings simulationSettings);

    public bool TryGetRandomEmptyLocation(IMap map, SimulationSettings simulationSettings, [MaybeNullWhen(false)] out Node node)
    {
        if (!HasFieldEmptyLocation(map, simulationSettings))
        {
            node = null;
            return false;
        }

        Node rndLocation;
        do
        {
            rndLocation = GetRandomLocation(simulationSettings);
        } while (!map.IsLocationEmpty(rndLocation));

        node = rndLocation;
        return true;
    }

    public Node GetRandomLocation(SimulationSettings simulationSettings)
    {
        Random rnd = new();

        int x = rnd.Next(0, simulationSettings.Field.GetFieldWidth() - 1);
        int y = rnd.Next(0, simulationSettings.Field.GetFieldHeight() - 1);
        return new Node(x, y);
    }

    public bool HasFieldEmptyLocation(IMap map, SimulationSettings simulationSettings)
    {
        return map.GetCount() < simulationSettings.Field.GetCellsCount();
    }

    public (int min, int max) GetEntityQuantityRange(Type type, IMap map, SimulationSettings simulationSettings)
    {
        int currentCount = map.GetCountByType(type);
        var staticObjectCountSettings = simulationSettings.Entities.GetEntitySettingsByType(type);

        int totalFieldCells = simulationSettings.Field.GetCellsCount();

        int minPercentArea = staticObjectCountSettings.PercentArea.MinPercentArea;
        int maxPercentArea = staticObjectCountSettings.PercentArea.MaxPercentArea;

        const int baseNumber = 100;

        int minCount = totalFieldCells * minPercentArea / baseNumber;
        int maxCount = totalFieldCells * maxPercentArea / baseNumber;
        return (minCount, maxCount);
    }
}