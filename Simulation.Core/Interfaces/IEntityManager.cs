﻿using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Interfaces;

public interface IEntityManager<in TKey, TEntity>
    where TKey : IEquatable<TKey>
    where TEntity : IEntity
{
    TEntity Get(TKey key);
    void Remove(TKey key);
    void Add(TEntity entity);
    HashSet<TEntity> GetAll();
    public int GetCountOfAll();

    int GetCountByType<T>() where T : IEntity;
    HashSet<TEntity> GetAllByType<T>() where T : IEntity;
}