using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Interfaces;

public interface IEntityManager
{
    IEntity Get(Guid id);
    void Remove(Guid id);
    void Add(IEntity entity);
    HashSet<IEntity> GetAll();
    int GetCountByType<T>() where T : IEntity;
    HashSet<IEntity> GetAllByType<T>() where T : IEntity;
}