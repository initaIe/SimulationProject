using Simulation.Core.Entities.Interfaces;
using Simulation.Core.POCOs;

namespace Simulation.Core.Interfaces;

public interface IMap : IEntityManager, IEntityLocationManager
{
    void Add(Node node, IEntity entity);

    void Remove(Node node);
    void Remove(IEntity entity);
}
public interface IEntityManager
{
    IEntity GetEntity(Node node);

    void UpdateEntity(Node node, IEntity newEntity);

    HashSet<IEntity> GetEntities();

    int GetCount();

    int GetCountByType(Type type);

    HashSet<IEntity> GetEntitesByType(Type type);

}

public interface IEntityLocationManager
{
    Node GetEntityLocation(IEntity entity);

    void UpdateLocation(IEntity entity, Node newNode);

    bool IsLocationEmpty(Node node);

    HashSet<Node> GetEntitiesLocationsByType(Type type);
    HashSet<Node> GetEntitiesLocations();
}
