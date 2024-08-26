namespace Simulation.Core.AStarAlgorithm;

/// <summary>
/// Представляет узел в алгоритме A*.
/// Инициализирует новый экземпляр класса с заданными координатами.
/// </summary>
/// <param name="x">Координата X узла.</param>
/// <param name="y">Координата Y узла.</param>
public class Node(int x, int y)
{

    /// <summary>
    /// Получает координату X узла.
    /// </summary>
    public int X { get; } = x;

    /// <summary>
    /// Получает координату Y узла.
    /// </summary>
    public int Y { get; } = y;

    /// <summary>
    /// Cтоимость диагонального/ортоганального перемещения от начального узла до данного узла.
    /// </summary>
    public int DirectionCost { get; private set; }

    /// <summary>
    /// Эвристическую стоимость (манхэттенское расстояние) до данного узла.
    /// </summary>
    public int HeuristicCost { get; private set; }

    /// <summary>
    /// Получает общую стоимость, равную сумме <see cref="DirectionCost"/> и <see cref="HeuristicCost"/>.
    /// </summary>
    public int TotalWeight => DirectionCost + HeuristicCost;

    /// <summary>
    /// Родительский узел, из которого был достигнут данный узел.
    /// </summary>
    public Node? Parent { get; private set; } = null;

    /// <summary>
    /// Устанавливает стоимость перемещения от начального узла до данного узла.
    /// </summary>
    /// <param name="directionCost">Стоимость перемещения.</param>
    public void SetDirectionCost(int directionCost)
    {
        DirectionCost = directionCost;
    }

    /// <summary>
    /// Устанавливает эвристическую стоимость до данного узла.
    /// </summary>
    /// <param name="heuristicCost">Эвристическая стоимость.</param>
    public void SetHeuristicCost(int heuristicCost)
    {
        HeuristicCost = heuristicCost;
    }

    /// <summary>
    /// Устанавливает родительский узел.
    /// </summary>
    /// <param name="parent">Родительский узел.</param>
    public void SetParent(Node parent)
    {
        Parent = parent;
    }

    /// <summary>
    /// Определяет, равены ли координаты одного узла координатам другого
    /// </summary>
    /// <param name="obj">Объект для сравнения.</param>
    /// <returns> true если объекты равны; в противном случае false.</returns>
    public override bool Equals(object obj)
    {
        return obj is Node node && X == node.X && Y == node.Y;
    }

    /// <summary>
    /// Возвращает хэш-код для данного узла используюя его координаты.
    /// </summary>
    /// <returns>Хэш-код для данного узла.</returns>
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}