using Simulation.Core.Interfaces.EntityInterfaces;
using Simulation.Core.POCO;

namespace Simulation.Core.Interfaces;

public interface IField<in TKey, TValue, TEntity>
    where TKey : IEquatable<TKey>
    where TEntity : IEntity
{
    void Add(TEntity entity, TValue value);
    void Remove(TKey key);
    void Update(TEntity entity, TValue value);
    TValue GetEntityLocation(TKey key);
    HashSet<TEntity> GetAllEntities();
    bool IsEntityLocationEmpty(TValue value);
    int GetTotalCountOfEntites();
    int GetCountOfEntitesByType<T>() where T : IEntity;
    HashSet<IEntity> GetAllEntitesByType<T>() where T : IEntity;
}

