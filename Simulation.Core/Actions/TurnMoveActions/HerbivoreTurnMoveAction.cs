using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Actions.TurnMoveActions;

public class HerbivoreTurnMoveAction<T> : EntityTurnMoveActionBase<Herbivore>
{
    protected override void InteractWithPrey(IMap map, ICreature creature, IEntity prey)
    {
        creature.Eat((IEatable)prey);
        map.Remove(prey);
    }
}