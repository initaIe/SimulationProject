using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Implementations.EntityImplementations;
public class Predator(string displayMark, int speed, int health, int damage)
    : CreatureBase(displayMark, speed, health), IPredator
{
    public int Damage { get; init; } = damage;
    public override void TurnMove()
    {
        //Может потратить ход на чтобы приблизиться к жертве или атаковать жертву
    }

    public void Attack()
    {

    }
}
