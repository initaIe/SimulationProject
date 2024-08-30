using Simulation.Core.Interfaces;
using Simulation.Core.POCO;
using Simulation.Core.Settings;

namespace Simulation.Core;
public class Simulation
{
    private readonly IField _field;
    private readonly IFieldRender _fieldRender;
    private readonly ITurnTracker _turnTracker;
    private readonly SimulationSettings _simulationSettings;


    public Simulation(
        IFieldRender fieldRender,
        ITurnTracker turnTracker,
        SimulationSettings simulationSettings,
        IField field)
    {
        _fieldRender = fieldRender;
        _turnTracker = turnTracker;
        _simulationSettings = simulationSettings;
        _field = field;
    }

    public HashSet<EntityRenderData> GetRenderEntityData()
    {
        HashSet<EntityRenderData> data = [];
        foreach (var entity in _entityManager.GetAll())
        {
            var coordinate = _entityLocationManager.GetLocation(entity.Id);
            data.Add(new EntityRenderData(entity.DisplayMark, coordinate));
        }
        return data;
    }


    //public void Start()
    //{

    //    var entityRenderData = GetRenderEntityData();
    //    _fieldRender.Render(entityRenderData);
    //}
}