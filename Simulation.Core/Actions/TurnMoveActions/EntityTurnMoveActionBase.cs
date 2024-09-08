using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.PathFinding;
using Simulation.Core.Settings;
using Simulation.Core.Utilities;

namespace Simulation.Core.Actions.TurnMoveActions;

public abstract class EntityTurnMoveActionBase<T> : IAction
    where T : ICreature
{
    public void Perform(IMap map, SimulationSettings simulationSettings)
    {
        var entitiesByType = map.GetEntitesByType(typeof(T));
        
        foreach (var entity in entitiesByType)
        {
            MakeTurnMove(map, entity, simulationSettings);
        }
    }

    protected abstract void InteractWithPrey(IMap map, ICreature creature, IEntity prey);

    private void MakeTurnMove(IMap map, IEntity entity, SimulationSettings simulationSettings)
    {
        var creature = (ICreature)entity;
    
        if (!EntityPreyUtils.TryGetClosestPrey(map, creature, simulationSettings, out var prey))
        {
            EntityMoveUtils.RandomMoveCreature(map, creature, simulationSettings.Field);
            return;
        }
        
        if (EntityInteractUtils.CanInteract(map, entity, prey, simulationSettings.Field))
        {
            InteractWithPrey(map, creature, prey);
            return;
        }
        
        if (!TryMoveToPrey(map, entity, prey, simulationSettings))
        {
            EntityMoveUtils.RandomMoveCreature(map, creature, simulationSettings.Field);
        }
    }
    
    private bool TryMoveToPrey(IMap map, IEntity entity, IEntity prey, SimulationSettings settings)
    {
        var creatureLocation = map.GetEntityLocation(entity);
        var preyLocation = map.GetEntityLocation(prey);

        var isPathExists = AstarPathfinder.TryFindPath(
            creatureLocation,
            preyLocation,
            EntityLocationUtils.GetLocationsOfBarriersExcludingEndpoints(map, entity, prey),
            settings.Field,
            out var path);

        if (isPathExists && path != null)
        {
            var nextLocation = path.First();
            EntityMoveUtils.MoveCreature(map, (ICreature)entity, nextLocation);
            return true;
        }

        return false;
    }
}