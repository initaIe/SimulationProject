using Simulation.Core.Interfaces;

namespace Simulation.Core;
public class Simulation
{
    private readonly IMap _map;
    private readonly IField _field;
    private readonly IFieldRender _fieldRender;
    private readonly ITurnTracker _turnTracker;
    private readonly SimulationSettings _simulationSettings;

    private Simulation
        (IMap map, IField field, IFieldRender fieldRender,
        ITurnTracker turnTracker, SimulationSettings simulationSettings)
    {
        _map = map;
        _field = field;
        _fieldRender = fieldRender;
        _turnTracker = turnTracker;
        _simulationSettings = simulationSettings;
    }

    public void NextTurn()
    {

    }

    public void Start()
    {
        
    }
    public void Pause()
    {

    }
}