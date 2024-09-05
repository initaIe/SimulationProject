using Simulation.Core.POCOs;
using Simulation.Core.Utilities;

namespace Simulation.Core.PathFinding;

public static class AstarPathfinder
{
    public static List<Node> FindPath(Node start, Node final, HashSet<Node> barriers, int fieldWidth, int fieldHeight)
    {
        ArgumentNullException.ThrowIfNull(start, nameof(start));
        ArgumentNullException.ThrowIfNull(final, nameof(final));
        ArgumentNullException.ThrowIfNull(barriers, nameof(barriers));
        if (fieldWidth == 0) throw new ArgumentException("Field width can not be zero.", nameof(fieldWidth));
        if (fieldHeight == 0) throw new ArgumentException("Field height can not be zero.", nameof(fieldHeight));

        var openList = new HashSet<Node> { start };
        var closedList = new HashSet<Node>();

        while (openList.Count > 0)
        {
            var current = AStarPathFindingUtils.GetLowestCostNode(openList);

            openList.Remove(current);
            closedList.Add(current);

            // Если финальный узел достигнут, возвращает к нему путь
            if (AStarPathFindingUtils.IsPathFounded(current, final))
                return AStarPathFindingUtils.GetNodePath(start, current);

            foreach (var neighbor in AStarPathFindingUtils.GetNeighbors(current, fieldWidth, fieldHeight))
            {
                if (AStarPathFindingUtils.IsBarrier(neighbor, barriers) ||
                    AStarPathFindingUtils.IsInClosedList(neighbor, closedList))
                    continue;

                // Стоиомсть *направления* от текущего узла до соседа
                int directionCostToNeighbor = AStarPathFindingUtils.GetDirectionCost(current, neighbor);

                // Новая стоимость DirectionCost для соседа
                int newNeighborDirectionCost = current.DirectionCost + directionCostToNeighbor;

                // Проверка newNeighborDirectionCost >= neighbor.DirectionCost
                // отбрасывает невыгодный путь к соседу
                if (newNeighborDirectionCost >= neighbor.DirectionCost &&
                    AStarPathFindingUtils.IsInOpenList(neighbor, openList))
                    continue;

                neighbor.DirectionCost = newNeighborDirectionCost;
                neighbor.HeuristicCost = AStarPathFindingUtils.GetHeuristicCost(neighbor, final);
                neighbor.Parent = current;
                openList.Add(neighbor);
            }
        }
        // Если путь не существует, возвращает пустой массив.
        return [];
    }
}