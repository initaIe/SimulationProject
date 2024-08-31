using Simulation.Core.Entities.Base;
using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Entities;
/// <summary>
/// Объект хищник.
/// </summary>
/// <param name="displayMark">Отображаемая марка объекта</param>
/// <param name="speed">Скорость объекта</param>
/// <param name="health">Здоровье объекта</param>
/// <param name="damage">Урон объекта</param>
public class Predator(string displayMark, int speed, int health, int damage)
    : CreatureBase(displayMark, speed, health), IPredator
{
    public int Damage { get; init; } = damage;
    public override void TurnMove()
    {
        //Может потратить ход на чтобы приблизиться к жертве или атаковать жертву
    }

    public void Attack(IHerbivore preyHerbivore)
    {
        preyHerbivore.TakeDamage(Damage);
    }
}
