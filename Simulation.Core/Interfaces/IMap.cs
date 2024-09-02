using Simulation.Core.Entities.Interfaces;
using Simulation.Core.POCOs;

namespace Simulation.Core.Interfaces;

public interface IMap : IEntityManager, IEntityLocationManager
{
    public void Add(Node node, IEntity entity);

    public void Remove(Node node);
}
public interface IEntityManager
{
    public IEntity GetEntity(Node node);

    public void UpdateEntity(Node node, IEntity newEntity);

    public HashSet<IEntity> GetEntities();

    public int GetCount();

    public int GetCountByType(Type type);

    public HashSet<IEntity> GetEntitesByType(Type type);

}

public interface IEntityLocationManager
{
    public Node GetEntityLocation(IEntity entity);

    public void UpdateLocation(IEntity entity, Node newNode);

    public bool IsLocationEmpty(Node node);

    public HashSet<Node> GetEntitiesLocationsByType(Type type);
}
