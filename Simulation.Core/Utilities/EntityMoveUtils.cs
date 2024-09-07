using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;

namespace Simulation.Core.Utilities;

// TODO: rework movement using entities speed.
public static class EntityMoveUtils
{
    private static readonly Random Random = new();

    public static void MoveCreature(IMap map, ICreature creature, Node final)
    {
        map.UpdateLocation((IEntity)creature, final);
    }

    public static void RandomMoveCreature(IMap map, ICreature creature, FieldSettings fieldSettings)
    {
        var creatureLocation = map.GetEntityLocation((IEntity)creature);
        var neighbors = AStarPathFindingUtils.GetNeighbors(creatureLocation, fieldSettings.GetFieldWidth(),
            fieldSettings.GetFieldHeight());
        
        // TODO: проверять чтобы не пиздовал туда где есть объект, пока костыль
        foreach (var neighbor in neighbors)
        {
            var randomIndex = Random.Next(0, neighbors.Count);
            var locationToMove = neighbors.ElementAt(randomIndex);
            if (map.IsLocationEmpty(locationToMove))
            {
                MoveCreature(map, creature, locationToMove);
            }
        }
    }
}