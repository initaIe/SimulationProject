using Simulation.Core.Entities.Base;
using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Entities;
/// <summary>
/// Объект травоядное.
/// </summary>
/// <param name="displayMark">Отображаемая марка объекта.</param>
/// <param name="speed">Скорость объекта.</param>
/// <param name="health">Здоровье объекта.</param>
public class Herbivore(string displayMark, int speed, int health)
    : CreatureBase(displayMark, speed, health), IHerbivore
{
    public void TakeDamage(int damage) => Health -= damage;
    public override void TurnMove()
    {
        //может потратить ход на поиск травы либо на ее поглащение
    }
}