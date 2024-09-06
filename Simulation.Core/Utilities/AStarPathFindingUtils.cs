using Simulation.Core.Enums;
using Simulation.Core.POCOs;

namespace Simulation.Core.Utilities;

internal static class AStarPathFindingUtils
{
    public static List<Node> GetNodePath(Node start, Node final)
    {
        var path = new List<Node>();
        var currentNode = final;

        while (!Equals(currentNode, start))
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        path.Reverse();
        
        return path;
    }

    public static bool IsCoordinateInRange(Node node, int fieldWidth, int fieldHeight)
    {
        return node.X >= 0 && node.X < fieldWidth && node.Y >= 0 && node.Y < fieldHeight;
    }

    public static int GetHeuristicCost(Node start, Node final)
    {
        return (Math.Abs(start.X - final.X) + Math.Abs(start.Y - final.Y)) * (int)AStarMovementCost.Manhattan;
    }

    public static int GetDirectionCost(Node current, Node neighbor)
    {
        return IsDiagonalDirection(current, neighbor) ? (int)AStarMovementCost.Diagonal : (int)AStarMovementCost.Orthogonal;
    }

    public static bool IsDiagonalDirection(Node current, Node neighbor)
    {
        return current.X != neighbor.X && current.Y != neighbor.Y;
    }

    public static List<Node> GetNeighbors(Node node, int fieldWidth, int fieldHeight)
    {
        var directions = new (int x, int y)[]
        {
            (-1,-1),(-1,0),(-1,1),
            (0, -1),       (0, 1),
            (1, -1),(1, 0),(1, 1)
        };

        return directions
            .Select(z => new Node(node.X + z.x, node.Y + z.y))
            .Where(neighbor => IsCoordinateInRange(neighbor, fieldWidth, fieldHeight))
            .ToList();
    }

    public static bool IsPathFounded(Node current, Node final)
    {
        return current.X == final.X && current.Y == final.Y;
    }

    public static bool IsBarrier(Node node, HashSet<Node> barriers)
    {
        return barriers.Contains(node);
    }

    public static bool IsInClosedList(Node node, HashSet<Node> closedList)
    {
        return closedList.Contains(node);
    }

    public static bool IsInOpenList(Node node, HashSet<Node> openList)
    {
        return openList.Contains(node);
    }

    public static Node GetLowestCostNode(HashSet<Node> openList)
    {
        return openList.OrderBy(n => n.TotalCost).ThenBy(n => n.DirectionCost).First();
    }
}