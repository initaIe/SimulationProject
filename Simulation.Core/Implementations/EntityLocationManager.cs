using Simulation.Core.Interfaces;
using Simulation.Core.POCO;

namespace Simulation.Core.Implementations;
public class EntityLocationManager : IEntityLocationManager<Guid, Node>
{
    private readonly Dictionary<Guid, Node> _entitiesLocation = [];

    public Node Get(Guid id)
    {
        if (_entitiesLocation.TryGetValue(id, out var node))
        {
            return node;
        }
        throw new KeyNotFoundException($"Node with ID {id} not found.");
    }

    public void Add(Guid id, Node node)
    {
        if (!_entitiesLocation.TryAdd(id, node))
        {
            throw new ArgumentException($"Node with ID {id} already exists.");
        }
    }

    public void Remove(Guid id)
    {
        if (!_entitiesLocation.Remove(id))
        {
            throw new KeyNotFoundException($"Node with ID {id} not found.");
        }
    }

    public bool IsLocationEmpty(Node node)
    {
        return !_entitiesLocation.ContainsValue(node);
    }
}