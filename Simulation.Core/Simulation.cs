using Simulation.Core.Interfaces;
using Simulation.Core.POCO;
using Simulation.Core.Settings;

namespace Simulation.Core;
public class Simulation
{
    private readonly IMap _map;
    private readonly IEntityManager _entityManager;
    private readonly IFieldRender _fieldRender;
    private readonly ITurnTracker _turnTracker;
    private readonly SimulationSettings _simulationSettings;


    public Simulation(
        IMap map,
        IEntityManager entityManager,
        IFieldRender fieldRender,
        ITurnTracker turnTracker,
        SimulationSettings simulationSettings)
    {
        _map = map;
        _entityManager = entityManager;
        _fieldRender = fieldRender;
        _turnTracker = turnTracker;
        _simulationSettings = simulationSettings;
    }

    public HashSet<EntityRenderData> GetRenderEntityData()
    {
        HashSet<EntityRenderData> data = [];
        foreach (var entity in _entityManager.GetAll())
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