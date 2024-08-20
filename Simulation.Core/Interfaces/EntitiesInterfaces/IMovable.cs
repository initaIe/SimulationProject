namespace Simulation.Core.Interfaces.EntitiesInterfaces;

public interface IMovable : IMovableProperties, IMovableMethods
{
}
public interface IMovableProperties
{
    int Speed { get; }
}
public interface IMovableMethods
{
    void Move();
}