using Simulation.Core.Implementations;
using Simulation.Core.Interfaces.EntityInterfaces;
using Simulation.Core.POCO;

namespace Simulation.Core.Interfaces;

public interface IField
{
    public void Remove(Guid id);
    public Node GetEntityLocation(Guid id);
    public HashSet<IEntity> GetAllEntities();
    public void Add(IEntity entity, Node node);
    public bool IsEntityLocationEmpty(Node node);
    public void Update(Guid id, IEntity entity, Node node);
    public int GetCountOfEntitesByType<T>() where T : IEntity;
    public HashSet<IEntity> GetAllEntitesByType<T>() where T : IEntity;
}

