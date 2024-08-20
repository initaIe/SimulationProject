namespace Simulation.Core.Interfaces;

public interface IMap<TKey, TValue>
{
    TValue Get(TKey entityId);

    void Add(TKey entityId, TValue coordinates);

    void Delete(TKey entityId);

    void Edit(TKey entityId, TValue coordinates);
}