using Simulation.Core.BaseClasses;
using Simulation.Core.Interfaces.EntityInterfaces;

namespace Simulation.Core.Implementations.EntityImplementations;
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