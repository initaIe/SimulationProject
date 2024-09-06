using Simulation.Core.Actions;
using Simulation.Core.Actions.CreationActions;
using Simulation.Core.Actions.TurnMoveActions;
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
    private readonly List<IAction> _initActions = [];
    private readonly List<IAction> _turnActions = [];

    public void Start()
    {
        CreateActions();
        _initActions.ForEach(a => a.Perform(_map, _settings));
        while (true)
        {
            _turnActions.ForEach(a => a.Perform(_map, _settings));
            _fieldRender.Render(_settings.Field, ConsoleRenderUtils.GetRenderEntityData(_map));
            Thread.Sleep(1000);
        }
    }

    private void CreateActions()
    {
        _initActions.Add(new StaticObjectCreationAction());
        _initActions.Add(new FoodCreationAction());
        _initActions.Add(new HerbivoreCreationAction());
        _initActions.Add(new PredatorCreationAction());

        _turnActions.Add(new HerbivoreTurnMoveAction());
        _turnActions.Add(new PredatorTurnMoveAction());
    }
}