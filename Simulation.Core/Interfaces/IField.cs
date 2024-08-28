using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Interfaces;

public interface IField
{
    IEntity GetEntity(Guid id);
    void DeleteEntity(Guid id);
    void AddEntity(IEntity entity);
    void UpdateEntity(Guid id, IEntity entity);
    int GetEntityCountByType(Type type);
    HashSet<IEntity> GetAll();

}
