using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;

namespace Simulation.Core.Utilities;

public static class EntityInteractUtils
{
    public static bool CanInteract(IMap map, IEntity interacter, IEntity target, FieldSettings fieldSettings)
    {
        var interacterLocation = map.GetEntityLocation(interacter);
        var targetLocation = map.GetEntityLocation(target);

        var neighborCells = AStarPathFindingUtils.GetNeighborCells(interacterLocation, fieldSettings.GetFieldWidth(),
            fieldSettings.GetFieldHeight());

        return neighborCells.Contains(targetLocation);
    }
}