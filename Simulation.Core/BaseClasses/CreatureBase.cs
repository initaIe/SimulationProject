using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.BaseClasses;
public abstract class CreatureBase(string displayMark, int speed, int health)
    : EntityBase(displayMark), ICreature
{
    public int Speed { get; init; } = speed;
    public int Health { get; protected set; } = health;

    public abstract void TurnMove();

    public void Move()
    {
        throw new NotImplementedException();
    }

    public void Eat(int satiety) => Health += satiety;
}