using Simulation.Core.Interfaces;
using Simulation.Core.Settings;

namespace Simulation.Core.Actions.TurnMoveActions;
public abstract class TurnMoveCreatureActionBase : IAction
{
    public abstract void Perform(IMap map, SimulationSettings simulationSettings);
    protected abstract void MakeTurnMove(IMap map, SimulationSettings simulationSettings);
}