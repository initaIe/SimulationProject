using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.PathFinding;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Interfaces;
using System.Diagnostics.CodeAnalysis;

namespace Simulation.Core.Utilities;

public static class EntityPreyUtils
{
    // TODO: NEED REFACTORING
    public static bool TryGetClosestPrey(
        IMap map,
        ICreature creature,
        SimulationSettings simulationSettings,
        [MaybeNullWhen(false)] out IEntity closestPrey)
    {
        var creatureLocation = map.GetEntityLocation((IEntity)creature);

        var preys = GetPreysForCreature(map, creature.GetType(), simulationSettings.Entities);

        closestPrey = preys
            .Select(prey => new
            {
                Prey = prey,
                PathCost = AstarPathfinder.TryFindPathCost(
                    map,
                    creatureLocation,
                    map.GetEntityLocation(prey),
                    EntityLocationUtils.GetLocationsOfBarriersExcludingEndpoints(map, (IEntity)creature, prey),
                    simulationSettings.Field,
                    out var cost) ? cost : (int?)null
            })
            .Where(result => result.PathCost.HasValue)
            .MinBy(result => result.PathCost)?.Prey;

        return closestPrey != null;
    }

    public static HashSet<Type> GetPreyTypesForCreature(Type creatureType, EntitiesSettings entitiesSettings)
    {
        var settings = (ICreatureSettings)entitiesSettings.GetEntitySettingsByType(creatureType);
        return settings.Preys.Preys;
    }

    public static HashSet<IEntity> GetPreysForCreature(IMap map, Type creatureType, EntitiesSettings entitiesSettings)
    {
        return
        [
            .. GetPreyTypesForCreature(creatureType, entitiesSettings)
                .SelectMany(map.GetEntitesByType)
        ];
    }
}