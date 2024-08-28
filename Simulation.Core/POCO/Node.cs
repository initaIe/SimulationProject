namespace Simulation.Core.POCO;

public class Node(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public int DirectionCost { get; set; }
    public int HeuristicCost { get; set; }
    public int TotalCost => DirectionCost + HeuristicCost;
    public Node? Parent { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is null) throw new ArgumentException("Некорректное значение параметра");
        return obj is Node node && X == node.X && Y == node.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}