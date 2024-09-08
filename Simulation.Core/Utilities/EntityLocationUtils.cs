using Simulation.Core.Entities;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;
using System.Diagnostics.CodeAnalysis;
using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Utilities;

public static class EntityLocationUtils
{
    private static readonly Random Random = new();

    // TODO: this method needs to be reworked/optimized.
    public static bool TryGetRandomEmptyLocation(
        IMap map, FieldSettings fieldSettings,
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

    public static Node GetRandomLocation(FieldSettings fieldSettings)
    {
        int x = Random.Next(0, fieldSettings.GetFieldWidth());
        int y = Random.Next(0, fieldSettings.GetFieldHeight());
        return new Node(x, y);
    }

    public static bool HasFieldEmptyLocation(IMap map, FieldSettings fieldSettings)
    {
        return map.GetCount() < fieldSettings.GetCellsCount();
    }

    public static HashSet<Node> GetLocationsOfBarriers(IMap map)
    {
        return map.GetEntitiesLocations();
    }

    public static HashSet<Node> GetLocationsOfBarriersExcludingEndpoints(IMap map, IEntity startEntity,
        IEntity endEntity)
    {
        var startEntityLocation = map.GetEntityLocation(startEntity);
        var endEntityLocation = map.GetEntityLocation(endEntity);
        
        return map.GetEntitiesLocations()
            .Where(node => !node.Equals(startEntityLocation) && !node.Equals(endEntityLocation)).ToHashSet();
    }
}