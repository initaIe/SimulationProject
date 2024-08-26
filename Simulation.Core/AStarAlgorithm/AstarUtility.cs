namespace Simulation.Core.AStarAlgorithm;

public static class AstarUtility
{
    public static List<Node> GetNodePath(Node start, Node end)
    {
        var path = new List<Node>();
        var currentNode = end;

        while (!Equals(currentNode, start))
        {
            path.Add(currentNode);
            currentNode = currentNode.Parent;
        }

        path.Reverse();
        return path;
    }

    public static bool IsValidCoordinates(Node node)
    {
        return node is { X: >= 0, Y: >= 0 };
    }

    public static int GetHeuristicPrice(Node start, Node final)
    {
        return Math.Abs(start.X - final.X) + Math.Abs(start.Y - final.Y) * (int)MovementCost.Manhattan;
    }

    public static int GetDirectionPrice(Node current, Node neighbor) =>
        IsDiagonalDirection(current, neighbor) ? (int)MovementCost.Diagonal : (int)MovementCost.Orthogonal;

    public static bool IsDiagonalDirection(Node current, Node neighbor) =>
         (current.X != neighbor.X && current.Y != neighbor.Y);

    public static List<Node> GetNeighbors(Node node)
    {
        var directions = new (int x, int y)[]
        {
            (-1,-1),(-1,0),(-1,1),
            (0, -1),       (0, 1),
            (1, -1),(1, 0),(1, 1)
        };

        var neighbors = new List<Node>();

        foreach (var (x, y) in directions)
        {
            var newNode = new Node(node.X + x, node.Y + y);
            if (IsValidCoordinates(newNode))
                neighbors.Add(newNode);
        }
        return neighbors;
    }
}
