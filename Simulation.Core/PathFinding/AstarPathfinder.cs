using Simulation.Core.POCOs;
using Simulation.Core.Settings;
using Simulation.Core.Utilities;
using System.Diagnostics.CodeAnalysis;
using Simulation.Core.Interfaces;

namespace Simulation.Core.PathFinding;

public static class AstarPathfinder
{
    public static bool TryFindPath(
        Node start,
        Node final,
        HashSet<Node> barriers,
        FieldSettings fieldSettings,
        [MaybeNullWhen(false)] out List<Node> path)
    {
        ArgumentNullException.ThrowIfNull(start, nameof(start));
        ArgumentNullException.ThrowIfNull(final, nameof(final));
        ArgumentNullException.ThrowIfNull(barriers, nameof(barriers));
        if (fieldSettings.GetFieldWidth() == 0)
            throw new ArgumentException("Field width can not be zero.", nameof(fieldSettings.SizeSettings.FieldWidth));
        if (fieldSettings.GetFieldHeight() == 0)
            throw new ArgumentException("Field height can not be zero.", nameof(fieldSettings.SizeSettings.FieldHeight));

        var openList = new HashSet<Node> { start };
        var closedList = new HashSet<Node>();

        while (openList.Count > 0)
        {
            var current = AStarPathFindingUtils.GetLowestCostNode(openList);

            openList.Remove(current);
            closedList.Add(current);

            // Если финальный узел достигнут, возвращает к нему путь
            if (AStarPathFindingUtils.IsPathFounded(current, final))
            {
                path = AStarPathFindingUtils.GetNodePath(start, current);
                return true;
            }

            var neighbors = AStarPathFindingUtils.GetNeighbors
                (current, fieldSettings.GetFieldWidth(), fieldSettings.GetFieldHeight());

            foreach (var neighbor in neighbors)
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
        path = null;
        return false;
    }

    public static bool TryFindPathCost(
        IMap map,
        Node start,
        Node end,
        HashSet<Node> barriers,
        FieldSettings fieldSettings,
        out int? cost)
    {
        AstarPathfinder.TryFindPath(start, end, barriers, fieldSettings, out var path);
        if (path == null || !path.Any())
        {
            cost = null;
            return false;
        }

        cost = path[^1].TotalCost;
        return true;
    }
}