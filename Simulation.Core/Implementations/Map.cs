using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;

namespace Simulation.Core.Implementations;
public class Map : IMap
{   
    private readonly Dictionary<Node, IEntity> _entities = [];

    public void Add(Node node, IEntity entity)
    {
        if (!_entities.TryAdd(node, entity))
        {
            throw new ArgumentException($"Key {node} already exists.");
        }
    }

    public void Remove(Node node)
    {
        if (!_entities.Remove(node))
        {
            throw new KeyNotFoundException($"Key {node} not found.");
        }
    }
    
    public void Remove(IEntity entity)
    {
        var location = GetEntityLocation(entity);
        _entities.Remove(location);
    }

    public IEntity GetEntity(Node node)
    {
        if (!_entities.TryGetValue(node, out var entity))
        {
            throw new KeyNotFoundException($"Entity with node {node} not found.");
        }
        return entity;
    }

    public Node GetEntityLocation(IEntity entity)
    {
        var node = _entities.FirstOrDefault(x => x.Value.Equals(entity)).Key;

        return node ?? throw new KeyNotFoundException($"Key with entity {entity} not found.");
    }

    public void UpdateEntity(Node node, IEntity newEntity)
    {
        if (!_entities.ContainsKey(node))
        {
            throw new KeyNotFoundException("Entity not found.");
        }
        _entities[node] = newEntity;
    }

    public void UpdateLocation(IEntity entity, Node newNode)
    {
        if (!_entities.ContainsValue(entity))
        {
            throw new KeyNotFoundException("Entity not found.");
        }

        var key = _entities.First(x => x.Value.Equals(entity)).Key;

        Remove(key);
        Add(newNode, entity);
    }

    public HashSet<IEntity> GetEntities()
    {
        return [.. _entities.Values];
    }

    public int GetCount()
    {
        return _entities.Count;
    }

    public int GetCountByType(Type type)
    {

        return _entities.Count(x => x.Value.GetType() == type);
    }

    public HashSet<IEntity> GetEntitesByType(Type type)
    {
        return
        [
            .. _entities.Values.Where(x => x.GetType() == type)
        ];
    }

    public bool IsLocationEmpty(Node node)
    {
        return !_entities.ContainsKey(node);
    }

    public HashSet<Node> GetEntitiesLocationsByType(Type type)
    {
        return
        [
            .. _entities
                .Where(x => x.Value.GetType() == type)
                .Select(z => z.Key)
        ];
    }
    public HashSet<Node> GetEntitiesLocations()
    {
        return
        [
            .. _entities
                .Select(z => z.Key)
        ];
    }

}