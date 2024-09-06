using Simulation.Core.Actions;
using Simulation.Core.Actions.CreationActions;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;
using Simulation.Core.Utilities;

namespace Simulation.Core;
public class Simulation(
    IMap map,
    IFieldRender fieldRender,
    ITurnTracker turnTracker,
    SimulationSettings settings)
{
    private readonly IMap _map = map;
    private readonly IFieldRender _fieldRender = fieldRender;
    private readonly ITurnTracker _turnTracker = turnTracker;
    private readonly SimulationSettings _settings = settings;
    private readonly List<IAction> _actions = [];
    public void Start()
    {
        CreateActions();
        while (true)
        {
            _actions.ForEach(a => a.Perform(_map, _settings));
            _fieldRender.Render(_settings.Field, ConsoleRenderUtils.GetRenderEntityData(_map));
            Thread.Sleep(500);
        }
    }
    private void CreateActions()
    {
        _actions.Add(new StaticObjectCreationAction());
        _actions.Add(new FoodCreationAction());
        _actions.Add(new HerbivoreCreationAction());
        _actions.Add(new PredatorCreationAction());
        
        _actions.Add(new HerbivoreCreationAction());
        _actions.Add(new PredatorCreationAction());
    }
}