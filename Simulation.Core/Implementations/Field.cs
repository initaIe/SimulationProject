﻿using Simulation.Core.Interfaces;
using Simulation.Core.Interfaces.EntityInterfaces;
using Simulation.Core.POCO;

namespace Simulation.Core.Implementations;
/// <summary>
/// Фасад который через свои методы делегирует выполнение работы компонентам и их методам.
/// </summary>
public class Field : IField
{
    private readonly EntityManager _entityManager = new();
    private readonly EntityLocationManager _entityLocationManager = new();

    #region General delegating methods
    public void Add(IEntity entity, Node node)
    {
        _entityManager.Add(entity);
        _entityLocationManager.Add(entity.Id, node);
    }

    public void Remove(Guid id)
    {
        _entityManager.Remove(id);
        _entityLocationManager.Remove(id);
    }

    public void Update(Guid id, IEntity entity, Node node)
    {
        _entityManager.Remove(id);
        _entityManager.Add(entity);

        _entityLocationManager.Remove(id);
        _entityLocationManager.Add(entity.Id, node);
    }

    #endregion

    #region Entity methods

    public HashSet<IEntity> GetAllEntities()
    {
        return _entityManager.GetAll();
    }

    public HashSet<IEntity> GetAllEntitesByType<T>() where T : IEntity
    {
        return _entityManager.GetAllByType<T>();
    }

    public int GetCountOfEntitesByType<T>() where T : IEntity
    {
        return _entityManager.GetCountByType<T>();
    }

    #endregion

    #region EntityLocation methods

    public Node GetEntityLocation(Guid id)
    {
        return _entityLocationManager.Get(id);
    }

    public bool IsEntityLocationEmpty(Node node)
    {
        return _entityLocationManager.IsLocationEmpty(node);
    }
    #endregion
}