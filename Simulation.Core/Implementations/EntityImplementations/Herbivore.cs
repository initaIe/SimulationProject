using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Implementations.EntityImplementations;

public class Herbivore(string displayMark, int speed, int health)
    : CreatureBase(displayMark, speed, health), IHerbivore
{
    public void TakeDamage(int damage) => Health -= damage;
    public override void TurnMove()
    {
        //может потратить ход на поиск травы либо на ее поглащение
    }
}