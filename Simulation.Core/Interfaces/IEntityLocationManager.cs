using Simulation.Core.POCO;

namespace Simulation.Core.Interfaces;

public interface IEntityLocationManager
{
    public Node Get(Guid id);
    public void Remove(Guid id);
    public void Add(Guid id, Node node);
    public bool IsLocationEmpty(Node node);
}