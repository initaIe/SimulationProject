using Simulation.Core.Implementations;
using Simulation.Core.Interfaces;
using Simulation.Core.POCO;

namespace Simulation.Services.Implementations;
public class Simulation
{
    private readonly IMap _map;
    private readonly ITurnTracker _turnTracker;
    private readonly IFieldRender _fieldRender;
    private readonly SimulationSettings _simulationSettings;

    public Simulation
        (IMap map,
        ITurnTracker turnTracker,
        IFieldRender fieldRender,
        SimulationSettings simulationSettings)
    {
        _map = map;
        _turnTracker = turnTracker;
        _fieldRender = fieldRender;
        _simulationSettings = simulationSettings;
    }
}
