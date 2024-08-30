using Simulation.Core.Implementations.EntityImplementations;
using Simulation.Core.Interfaces;
using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Implementations;
public class EntityManager : IEntityManager
{
    private readonly IReadOnlyDictionary<Type, HashSet<IEntity>> _entities = new Dictionary<Type, HashSet<IEntity>>()
    {
        { typeof(StaticObject), [] },
        { typeof(Herbivore), [] },
        { typeof(Predator), [] },
        { typeof(Food), []}
    };

    public void Add(IEntity entity)
    {
        if (entity == null) throw new ArgumentNullException(nameof(entity));

        var type = entity.GetType();
        if (!_entities.TryGetValue(type, out var entitySet))
        {
            throw new ArgumentException($"Entity type {type} is not supported.");
        }

        entitySet.Add(entity);
    }

    public IEntity Get(Guid id) 
    {
        var entity = _entities.Values
            .SelectMany(entitySet => entitySet
            .Where(entity => entity.Id.Equals(id)))
            .FirstOrDefault();

        if (entity != null)
        {
            return entity;
        }

        throw new KeyNotFoundException($"Entity with ID {id} not found.");
    }

    public void Remove(Guid id)
    {
        foreach (var entitySet in _entities.Values)
        {
            var entityToRemove = entitySet.FirstOrDefault(entity => entity.Id.Equals(id));

            if (entityToRemove == null) continue;

            entitySet.Remove(entityToRemove);
            return;
        }
        throw new KeyNotFoundException($"Entity with ID {id} not found.");
    }

    public int GetCountByType<T>() where T : IEntity
    {
        var type = typeof(T);
        if (_entities.TryGetValue(type, out var entitySet))
        {
            return entitySet.Count;
        }
        throw new ArgumentException($"Entity type {type} is not supported.");
    }

    public HashSet<IEntity> GetAllByType<T>() where T : IEntity
    {
        var type = typeof(T);
        if (_entities.TryGetValue(type, out var set))
        {
            return [..set]; 
        }
        throw new ArgumentException($"Entity type {type} is not supported.");
    }

    public HashSet<IEntity> GetAll()
    {
        return [.. _entities.SelectMany(entitySet => entitySet.Value)];
    }
}