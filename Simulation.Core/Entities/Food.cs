using Simulation.Core.Entities.Base;
using Simulation.Core.Entities.Interfaces;

namespace Simulation.Core.Entities;
/// <summary>
/// Объект еды.
/// </summary>
/// <param name="displayMark">Отображаемая марка объекта.</param>
/// <param name="satiety">Сытность еды.</param>
public class Food(string displayMark, int satiety) : EntityBase(displayMark), IEatable
{
    public int Satiety { get; init; } = satiety;
}