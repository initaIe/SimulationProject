using Simulation.Core.Implementations;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;

namespace Simulation.Core;
public class Simulation
{
    private readonly IMap _map;
    private readonly IField _field;
    private readonly IFieldRender _fieldRender;
    private readonly ITurnTracker _turnTracker;
    private readonly SimulationSettings _simulationSettings;


    public Simulation(
        IMap map,
        IField field,
        IFieldRender fieldRender,
        ITurnTracker turnTracker,
        SimulationSettings simulationSettings)
    {
        _map = map;
        _field = field;
        _fieldRender = fieldRender;
        _turnTracker = turnTracker;
        _simulationSettings = simulationSettings;
    }

    public HashSet<EntityRenderData> GetRenderEntityData()
    {
        HashSet<EntityRenderData> data = [];
        foreach (var entity in _field.GetAll())
        {
            var coordinate = _map.GetEntityCoordinates(entity.Id);
            data.Add(new EntityRenderData(entity.DisplayMark, coordinate));
        }
        return data;
    }


    public void Start()
    {

        var entityRenderData = GetRenderEntityData();
        _fieldRender.Render(entityRenderData);
    }
}