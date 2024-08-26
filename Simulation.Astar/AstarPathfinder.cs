namespace Simulation.Astar;

public class AstarPathfinder
{
    public List<Node> FindPath(Node start, Node final, HashSet<Node> barriers, int fieldWidth, int fieldHeight)
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
            var current = Utility.GetLowestCostNode(openList);

            openList.Remove(current);
            closedList.Add(current);

            bool isPathFounded = Utility.IsPathFounded(current, final);
            if (isPathFounded) return Utility.GetNodePath(start, current);

            var neighbors = Utility.GetNeighbors(current, fieldWidth, fieldHeight);
            foreach (var neighbor in neighbors)
            {
                bool isBarrier = Utility.IsBarrier(neighbor, barriers);
                bool isProcessedNode = Utility.IsInClosedList(neighbor, closedList);
                if (isBarrier || isProcessedNode) continue;

                // Стоиомсть *направления* от текущего узла до соседа
                int directionCostToNeighbor = Utility.GetDirectionCost(current, neighbor);

                // Новая стоимость DirectionCost для соседа
                int newNeighborDirectionCost = current.DirectionCost + directionCostToNeighbor;

                bool isDetectedUnprocessedNode = Utility.IsInOpenList(neighbor, openList);
                // Проверка newNeighborDirectionCost >= neighbor.DirectionCost отбрасывает невыгодный путь к соседу
                if (newNeighborDirectionCost >= neighbor.DirectionCost && isDetectedUnprocessedNode) continue;

                neighbor.SetDirectionCost(newNeighborDirectionCost);

                int newHeuristicPrice = Utility.GetHeuristicCost(neighbor, final);
                neighbor.SetHeuristicCost(newHeuristicPrice);

                neighbor.SetParent(current);

                openList.Add(neighbor);
            }
        }
        return [];
    }
}