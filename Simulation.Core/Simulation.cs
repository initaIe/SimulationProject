using Simulation.Core.Interfaces;
using Simulation.Core.Settings;

namespace Simulation.Core;
public class Simulation(IMap map, IFieldRender fieldRender, ITurnTracker turnTracker, SimulationSettings settings)
{
    private readonly IMap _map = map;
    private readonly IFieldRender _fieldRender = fieldRender;
    private readonly ITurnTracker _turnTracker = turnTracker;
    private readonly SimulationSettings _settings = settings;
    
    
}