using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Actions.TurnMoveActions;

public class PredatorTurnMoveAction : EntityTurnMoveActionBase<Predator>
{
    protected override void InteractWithPrey(IMap map, ICreature creature, IEntity prey)
    {
        var predator = (IPredator)creature;
        var herbivorePrey = (IHerbivore)prey;
        predator.Attack(herbivorePrey);
        if (herbivorePrey.Health < 1)
        {
            map.Remove(prey);
        }
    }
}