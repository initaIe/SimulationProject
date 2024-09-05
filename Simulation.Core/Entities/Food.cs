using Simulation.Core.Entities.Base;
using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Entities;
/// <summary>
/// Объект еды.
/// </summary>
/// <param name="sprite">Отображаемая марка объекта.</param>
/// <param name="satiety">Сытность еды.</param>
public class Food(string sprite, int satiety) : EntityBase(sprite), IEatable
{
    public int Satiety { get; init; } = satiety;
}