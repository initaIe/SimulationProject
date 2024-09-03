using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace Simulation.Core.Actions;

public abstract class EntityCreationActionBase : IAction
{
    protected readonly Random Random = new();

    public abstract void Perform(IMap map, SimulationSettings simulationSettings);
    protected abstract IEntity CreateEntity(EntitiesSettings entitiesSettings);
    protected abstract void SpawnEntity(IMap map, SimulationSettings simulationSettings, IEntity entity);


    // Настройки лимитов(Минимальное кол-во, Максимальное кол-во) объектов задаются в % размере от кол-ва ячеек на поле.
    // Данный метод конвертирует проценты в зависимости от размера нашего поля уже в конкретные числа.
    protected LimitSettings GetLimitsOfObjectInNumbers(Type type, SimulationSettings simulationSettings)
    {
        var staticObjectCountSettings = simulationSettings.Entities.GetEntitySettingsByType(type);

        int totalCellsCount = simulationSettings.Field.GetCellsCount();

        int minPercentArea = staticObjectCountSettings.PercentArea.Min;
        int maxPercentArea = staticObjectCountSettings.PercentArea.Max;

        const int percentConversionFactor = 100;

        int minCount = totalCellsCount * minPercentArea / percentConversionFactor;
        int maxCount = totalCellsCount * maxPercentArea / percentConversionFactor;

        return new LimitSettings(minCount, maxCount);
    }

    protected bool TryGetRandomEmptyLocation(IMap map, FieldSettings fieldSettings,
        [MaybeNullWhen(false)] out Node emptyLocation)
    {
        if (!HasFieldEmptyLocation(map, fieldSettings))
        {
            emptyLocation = null;
            return false;
        }

        Node rndLocation;
        do
        {
            rndLocation = GetRandomLocation(fieldSettings);
        } while (!map.IsLocationEmpty(rndLocation));

        emptyLocation = rndLocation;
        return true;
    }

    private Node GetRandomLocation(FieldSettings fieldSettings)
    {
        int x = Random.Next(0, fieldSettings.GetFieldWidth() - 1);
        int y = Random.Next(0, fieldSettings.GetFieldHeight() - 1);
        return new Node(x, y);
    }

    private bool HasFieldEmptyLocation(IMap map, FieldSettings fieldSettings)
    {
        return map.GetCount() < fieldSettings.GetCellsCount();
    }

    protected int GetRandomValueInLimits(LimitSettings limitSettings)
    {
        return Random.Next(limitSettings.Min, limitSettings.Max);
    }
}