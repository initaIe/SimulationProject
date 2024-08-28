using Simulation.Core.BaseClasses;

namespace Simulation.Core.Implementations.EntityImplementations;
/// <summary>
/// Статический объект (Камень, дерево и тд).
/// </summary>
/// <param name="displayMark">Отображаемая марка объекта</param>
public class StaticObject(string displayMark) : EntityBase(displayMark);