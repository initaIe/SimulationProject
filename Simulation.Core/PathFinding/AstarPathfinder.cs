using Simulation.Core.POCOs;

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
            var current = PathFindingUtility.GetLowestCostNode(openList);

            openList.Remove(current);
            closedList.Add(current);

            // Если финальный узел достигнут, возвращает к нему путь
            if (PathFindingUtility.IsPathFounded(current, final))
                return PathFindingUtility.GetNodePath(start, current);

            foreach (var neighbor in PathFindingUtility.GetNeighbors(current, fieldWidth, fieldHeight))
            {
                if (PathFindingUtility.IsBarrier(neighbor, barriers) ||
                    PathFindingUtility.IsInClosedList(neighbor, closedList))
                    continue;

                // Стоиомсть *направления* от текущего узла до соседа
                int directionCostToNeighbor = PathFindingUtility.GetDirectionCost(current, neighbor);

                // Новая стоимость DirectionCost для соседа
                int newNeighborDirectionCost = current.DirectionCost + directionCostToNeighbor;

                // Проверка newNeighborDirectionCost >= neighbor.DirectionCost
                // отбрасывает невыгодный путь к соседу
                if (newNeighborDirectionCost >= neighbor.DirectionCost &&
                    PathFindingUtility.IsInOpenList(neighbor, openList))
                    continue;

                neighbor.DirectionCost = newNeighborDirectionCost;
                neighbor.HeuristicCost = PathFindingUtility.GetHeuristicCost(neighbor, final);
                neighbor.Parent = current;
                openList.Add(neighbor);
            }
        }
        // Если путь не существует, возвращает пустой массив.
        return [];
    }
}