using Simulation.Core.Entities.Base;

namespace Simulation.Core.Entities;
/// <summary>
/// Статический объект (Камень, дерево и тд).
/// </summary>
/// <param name="displayMark">Отображаемая марка объекта</param>
public class StaticObject(string displayMark) : EntityBase(displayMark);