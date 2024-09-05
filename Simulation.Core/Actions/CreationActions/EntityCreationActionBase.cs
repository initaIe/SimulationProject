using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace Simulation.Core.Actions.CreationActions;

public abstract class EntityCreationActionBase<T> : IAction where T : IEntity
{
    private readonly Random _random = new();

    public void Perform(IMap map, SimulationSettings simulationSettings)
    {
        var entityCountLimits = GetLimitsOfEntityInNumbers(typeof(T), simulationSettings);
        var entityRandomMaxLimitCount = GetRandomValueInLimits(entityCountLimits);

        while (map.GetCountByType(typeof(T)) < entityRandomMaxLimitCount)
        {
            var newEntity = CreateEntity(simulationSettings.Entities);
            SpawnEntity(map, simulationSettings, newEntity);
        }
    }
    protected abstract T CreateEntity(EntitiesSettings entitiesSettings);
    protected void SpawnEntity(IMap map, SimulationSettings simulationSettings, T entity)
    {
        if (!TryGetRandomEmptyLocation(map, simulationSettings.Field, out var rndLocation)) return;

        map.Add(rndLocation, entity);
    }


    /* Настройки лимитов(Минимальное кол-во, Максимальное кол-во) объектов задаются в % размере от кол-ва ячеек на поле.
    Данный метод конвертирует проценты в зависимости от размера нашего поля уже в конкретные числа. */
    protected LimitSettings GetLimitsOfEntityInNumbers(Type type, SimulationSettings simulationSettings)
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

    // TODO: this method needs to be reworked/optimized.
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

    // TODO: move location getting methods to static utility class.
    private Node GetRandomLocation(FieldSettings fieldSettings)
    {
        int x = _random.Next(0, fieldSettings.GetFieldWidth());
        int y = _random.Next(0, fieldSettings.GetFieldHeight());
        return new Node(x, y);
    }

    private bool HasFieldEmptyLocation(IMap map, FieldSettings fieldSettings)
    {
        return map.GetCount() < fieldSettings.GetCellsCount();
    }

    protected int GetRandomValueInLimits(LimitSettings limitSettings)
    {
        return _random.Next(limitSettings.Min, limitSettings.Max);
    }

    protected TItem GetRandomValue<TItem>(IEnumerable<TItem>? items)
    {
        if (items == null)
        {
            throw new ArgumentNullException(nameof(items), "Collection can not be null.");
        }

        var valueList = items.ToList();

        if (!valueList.Any())
        {
            throw new ArgumentNullException(nameof(valueList), "Collection can not be empty.");
        }

        int randomIndex = _random.Next(0, valueList.Count);

        var result = valueList.ElementAtOrDefault(randomIndex);

        if (result == null)
        {
            throw new ArgumentException("Value not found.");
        }

        return result;
    }
}