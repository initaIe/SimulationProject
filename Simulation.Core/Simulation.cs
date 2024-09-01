using System.Collections;
using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.PathFinding;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;
using System.Diagnostics.CodeAnalysis;

namespace Simulation.Core;
public class Simulation(
    IFieldRender fieldRender,
    ITurnTracker turnTracker,
    SimulationSettings simulationSettings,
    IField<Guid, Node, IEntity> field)
{
    private readonly IField<Guid, Node, IEntity> _field = field;
    private readonly IFieldRender _fieldRender = fieldRender;
    private readonly ITurnTracker _turnTracker = turnTracker;
    private readonly SimulationSettings _simulationSettings = simulationSettings;


    public HashSet<EntityRenderData> GetRenderEntityData()
    {
        HashSet<EntityRenderData> data = [];
        var allEntities = _field.GetAllEntities();
        foreach (var entity in allEntities)
        {
            var coordinate = _field.GetEntityLocation(entity.Id);
            data.Add(new EntityRenderData(entity.DisplayMark, coordinate));
        }
        return data;
    }

    public bool TryGetRandomEmptyLocation([MaybeNullWhen(false)] out Node node)
    {
        // Проверяем, есть ли вообще свободные места
        if (!HasFieldEmptyLocation())
        {
            node = null;
            return false;
        }

        Node rndLocation;

        // Генерируем случайное местоположение и проверяем, свободно ли оно
        do
        {
            rndLocation = GetRandomLocation();
        } while (!_field.IsEntityLocationEmpty(rndLocation));

        node = rndLocation;
        return true;
    }

    public Node GetRandomLocation()
    {
        Random rnd = new();

        var fieldSizeSettings = _simulationSettings.FieldSettings.Size;
        int x = rnd.Next(0, fieldSizeSettings.FieldWidth - 1);
        int y = rnd.Next(0, fieldSizeSettings.FieldHeight - 1);

        return new Node(x, y);
    }

    public bool HasFieldEmptyLocation()
    {
        var totalCells = GetTotalCellsCount();
        var totalEntites = _field.GetTotalCountOfEntites();
        return totalEntites < totalCells;
    }

    public int GetTotalCellsCount()
    {
        var fieldSizeSettings = _simulationSettings.FieldSettings.Size;
        return fieldSizeSettings.FieldHeight * fieldSizeSettings.FieldWidth;
    }

    public void MoveCreature(ICreature creature, Node final)
    {
        if (creature is IEntity entity)
        {
            _field.Update(entity, final);
        }
    }

    public IEntity? GetClosestPrey(ICreature creature)
    {
        if (creature is not IEntity entity) return null;

        var creatureLocation = _field.GetEntityLocation(entity.Id);
        var barriers = GetBarriers();
        int minTotalCost = int.MaxValue;
        IEntity? closestPrey = null;

        foreach (var prey in GetPreyEntites(creature))
        {
            var entityLocation = _field.GetEntityLocation(prey.Id);
            var fieldSizeSettings = _simulationSettings.FieldSettings.Size;

            var path = AstarPathfinder.FindPath(
                creatureLocation,
                entityLocation,
                barriers,
                fieldSizeSettings.FieldWidth,
                fieldSizeSettings.FieldHeight);

            if (!path.Any()) continue;

            int totalCost = path[^1].TotalCost;

            if (totalCost < minTotalCost)
            {
                minTotalCost = totalCost;
                closestPrey = prey;
            }
        }
        return closestPrey;
    }

    public HashSet<Type>? GetPreyTypes(ICreature creature)
    {
        var preySettings = _simulationSettings.EntitiesSettings.Prey;
        preySettings.PreyEntities.TryGetValue(creature.GetType(), out var types);
        return types;
    }

    public HashSet<IEntity> GetPreyEntites(ICreature creature)
    {
        return GetPreyTypes(creature)?
            .SelectMany(type => _field.GetAllEntitesByType(type))
            .ToHashSet() ?? [];
    }

    public HashSet<Node> GetBarriers()
    {
        return _field.GetAllEntitesByType(typeof(StaticObject))
            .Select(staticObject => _field.GetEntityLocation(staticObject.Id))
            .ToHashSet();
    }
    Hashtable   
}