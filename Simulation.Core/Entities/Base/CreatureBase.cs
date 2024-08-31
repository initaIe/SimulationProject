using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Entities.Base;
public abstract class CreatureBase(string displayMark, int speed, int health)
    : EntityBase(displayMark), ICreature
{
    public int Speed { get; init; } = speed;
    public int Health { get; protected set; } = health;
    public abstract void TurnMove();
    public void Eat(int satiety) => Health += satiety;

}