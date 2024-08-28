using Simulation.Core.POCO;

namespace Simulation.Core.Interfaces;

public interface IMap
{
    Node GetEntityCoordinates(Guid id);

    void AddEntityCoordinates(Guid id, Node nodes);

    void DeleteEntityCoordinates(Guid id);

    void UpdateEntityCoordinates(Guid id, Node nodes);
}