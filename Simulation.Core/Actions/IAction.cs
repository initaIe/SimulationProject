using Simulation.Core.Interfaces;
using Simulation.Core.Settings;

namespace Simulation.Core.Actions;

public interface IAction
{
    void Perform(IMap map, SimulationSettings simulationSettings);
}
