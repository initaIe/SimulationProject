using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;

namespace Simulation.Core;
public class Simulation(
    IFieldRender fieldRender,
    ITurnTracker turnTracker,
    SimulationSettings simulationSettings,
    IMap map)
{
    private readonly IMap _map = map;
    private readonly IFieldRender _mapRender = fieldRender;
    private readonly ITurnTracker _turnTracker = turnTracker;
    private readonly SimulationSettings _simulationSettings = simulationSettings;


    public HashSet<EntityRenderData> GetRenderEntityData()
    {
        HashSet<EntityRenderData> data = [];
        var allEntities = _map.GetEntities();
        foreach (var entity in allEntities)
        {
            var coordinate = _map.GetEntityLocation(entity);
            data.Add(new EntityRenderData(entity.Sprite, coordinate));
        }
        return data;
    }



    public void MoveCreature(ICreature creature, Node final)
    {
        _map.UpdateLocation(UpcastCreatureToEntity(creature), final);
    }

    //public IEntity? GetClosestPrey(ICreature creature)
    //{
    //    var creatureLocation = _map.GetEntityLocation(UpcastCreatureToEntity(creature));
    //    var barriers = GetBarriers();
    //    int minTotalCost = int.MaxValue;
    //    IEntity? closestPrey = null;

    //    foreach (var prey in GetPreyEntites(creature))
    //    {
    //        var preyLocation = _map.GetEntityLocation(prey);
    //        var fieldSizeSettings = _simulationSettings.Field.SizeSettings;

    //        var path = AstarPathfinder.FindPath(
    //            creatureLocation,
    //            preyLocation,
    //            barriers,
    //            fieldSizeSettings.FieldWidth,
    //            fieldSizeSettings.FieldHeight);

    //        if (!path.Any()) continue;

    //        int totalCost = path[^1].TotalCost;

    //        if (totalCost < minTotalCost)
    //        {
    //            minTotalCost = totalCost;
    //            closestPrey = prey;
    //        }
    //    }
    //    return closestPrey;
    //}

    //public HashSet<Type> GetPreyTypes(ICreature creature)
    //{
    //    var preySettings = _simulationSettings.Entities.Preys.PreyEntities;
    //    return preySettings.TryGetValue(creature.GetType(), out var types) ? types : [];
    //}

    //public HashSet<IEntity> GetPreyEntites(ICreature creature)
    //{
    //    return GetPreyTypes(creature)?
    //        .SelectMany(type => _map.GetEntitesByType(type))
    //        .ToHashSet() ?? [];
    //}

    public HashSet<Node> GetBarriers()
    {
        return _map.GetEntitiesLocationsByType(typeof(StaticObject));
    }

    public Guid GetGuid(IEntity entity)
    {
        return entity.Id;
    }

    public IEntity UpcastCreatureToEntity(ICreature creature)
    {
        return (creature as IEntity)!;
    }
}