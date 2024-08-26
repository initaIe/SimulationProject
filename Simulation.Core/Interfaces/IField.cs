using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Interfaces;

public interface IField
{
    public IEntity GetEntity(Guid id);
    public void DeleteEntity(Guid id);
    public void AddEntity(IEntity entity);
    public void UpdateEntity(Guid id, IEntity entity);
    public int GetEntitiesCountByType(Type type);
}
