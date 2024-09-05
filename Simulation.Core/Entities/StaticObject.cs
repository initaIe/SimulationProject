using Simulation.Core.Entities.Base;

namespace Simulation.Core.Entities;
/// <summary>
/// Статический объект (Камень, дерево и тд).
/// </summary>
/// <param name="sprite">Отображаемая марка объекта</param>
public class StaticObject(string sprite) : EntityBase(sprite);