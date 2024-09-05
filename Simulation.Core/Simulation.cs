using Simulation.Core.Interfaces;
using Simulation.Core.Settings;

namespace Simulation.Core;
public class Simulation(
    IFieldRender fieldRender,
    ITurnTracker turnTracker,
    SimulationSettings simulationSettings,
    IMap map)
{
    private readonly IMap _map = map;
    private readonly IFieldRender _mapRender = fieldRender;
    private readonly ITurnTracker _turnTracker = turnTracker;
    private readonly SimulationSettings _simulationSettings = simulationSettings;

}