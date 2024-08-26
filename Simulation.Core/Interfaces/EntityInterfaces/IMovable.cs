namespace Simulation.Core.Interfaces.EntityInterfaces;

public interface IMovable : IMoveSpeed, IMoveAction;

public interface IMoveSpeed
{
    int Speed { get; init; }
}

public interface IMoveAction
{
    void Move();
}
