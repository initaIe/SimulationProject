namespace Simulation.Core.Interfaces;

public interface IEntityLocationManager<in TKey, TValue>
    where TKey : IEquatable<TKey>
{
    public TValue Get(TKey key);
    public void Remove(TKey key);
    public void Add(TKey id, TValue value);
    public bool IsLocationEmpty(TValue value);
}