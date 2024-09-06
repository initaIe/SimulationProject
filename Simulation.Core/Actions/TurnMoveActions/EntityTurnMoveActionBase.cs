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
        var entities = map.GetEntitesByType(typeof(T));
        
        foreach (var entity in entities)
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
            PerformRandomMove(map, creature, simulationSettings);
            return;
        }
        
        if (EntityInteractUtils.IsCloseEnoughToInteract(map, entity, prey, simulationSettings.Field))
        {
            InteractWithPrey(map, creature, prey);
            return;
        }
        
        if (!TryMoveToPrey(map, entity, prey, simulationSettings))
        {
            PerformRandomMove(map, creature, simulationSettings);
        }
    }
    
    private void PerformRandomMove(IMap map, ICreature creature, SimulationSettings settings)
    {
        EntityMoveUtils.RandomMoveCreature(map, creature, settings.Field);
    }
    
    private bool TryMoveToPrey(IMap map, IEntity entity, IEntity prey, SimulationSettings settings)
    {
        var creatureLocation = map.GetEntityLocation(entity);
        var preyLocation = map.GetEntityLocation(prey);

        var isPathExists = AstarPathfinder.TryFindPath(
            creatureLocation,
            preyLocation,
            EntityLocationUtils.GetBarrierLocations(map),
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