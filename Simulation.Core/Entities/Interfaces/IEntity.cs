namespace Simulation.Core.Entities.Interfaces;
public interface IEntity
{
    Guid Id { get; }
    string Sprite { get; }
}