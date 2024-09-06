using System.ComponentModel.Design;
using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Entities.Base;
public abstract class CreatureBase(string sprite, int speed, int health)
    : EntityBase(sprite), ICreature
{
    public int Speed { get; init; } = speed;
    public int Health { get; protected set; } = health;
    public void Eat(IEatable entity) => Health += entity.Satiety;
}