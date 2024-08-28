using Simulation.Core.Interfaces;
using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Implementations;
/// <summary>
/// Класс отвечает за хранение объектов которые находятся на поле, операции с ними.
/// </summary>
public class Field : IField
{
    private readonly HashSet<IEntity> _entities = [];
    public IEntity GetEntity(Guid id) => _entities.First(x => x.Id.Equals(id));
    public void DeleteEntity(Guid id) => _entities.RemoveWhere(x => x.Id.Equals(id));
    public void AddEntity(IEntity entity) => _entities.Add(entity);
    public void UpdateEntity(Guid id, IEntity entity)
    {
        DeleteEntity(id);
        AddEntity(entity);
    }
    public int GetEntityCountByType(Type type) => _entities.Count(x => x.GetType() == type);

    public HashSet<IEntity> GetAll() => _entities;
}
