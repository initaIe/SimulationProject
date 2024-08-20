using Simulation.Core.Interfaces;
using Simulation.Core.POCO;
using System.Collections.Generic;
using System.Linq;

namespace Simulation.Core.Implementations;

public class Map : IMap<Guid, Coordinates>
{
    private readonly Dictionary<Guid, Coordinates> _entitiesLocation = [];

    public Coordinates Get(Guid entityId) =>
         _entitiesLocation.First(x=>
             x.Key.Equals(entityId)).Value;

    public void Add(Guid entityId, Coordinates coordinates) =>
        _entitiesLocation.Add(entityId, coordinates);

    public void Delete(Guid entityId) =>
        _entitiesLocation.Remove(entityId);

    public void Edit(Guid entityId, Coordinates coordinates) =>
        _entitiesLocation[entityId] = coordinates;
}