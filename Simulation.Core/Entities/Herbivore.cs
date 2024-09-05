using Simulation.Core.Entities.Base;
using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Entities;
/// <summary>
/// Объект травоядное.
/// </summary>
/// <param name="sprite">Отображаемая марка объекта.</param>
/// <param name="speed">Скорость объекта.</param>
/// <param name="health">Здоровье объекта.</param>
public class Herbivore(string sprite, int speed, int health)
    : CreatureBase(sprite, speed, health), IHerbivore
{
    public void TakeDamage(int damage) => Health -= damage;
    public override void TurnMove()
    {
        //может потратить ход на поиск травы либо на ее поглащение
    }
}