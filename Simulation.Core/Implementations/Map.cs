using Simulation.Core.Interfaces;

namespace Simulation.Core.Implementations;
/// <summary>
/// Класс отвечает за расположение объектов, операции с ними.
/// </summary>
public class Map : IMap
{
    private readonly Dictionary<Guid, Node> _entitiesLocation = [];

    public Node GetEntityCoordinates(Guid entityId) =>
         _entitiesLocation.First(x =>
             x.Key.Equals(entityId)).Value;

    public void AddEntityCoordinates(Guid entityId, Node nodes) =>
        _entitiesLocation.Add(entityId, nodes);

    public void DeleteEntityCoordinates(Guid entityId) =>
        _entitiesLocation.Remove(entityId);

    public void UpdateEntityCoordinates(Guid entityId, Node nodes) =>
        _entitiesLocation[entityId] = nodes;

    public bool IsCellEmpty(Node node)
    {
        return !_entitiesLocation.ContainsValue(node);
    }
}