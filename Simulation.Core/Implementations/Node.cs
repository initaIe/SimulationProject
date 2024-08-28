namespace Simulation.Core.Implementations;

public class Node(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public int DirectionCost { get; private set; }
    public int HeuristicCost { get; private set; }
    public int TotalCost => DirectionCost + HeuristicCost;
    public Node? Parent { get; private set; }

    public void SetDirectionCost(int directionCost)
    {
        DirectionCost = directionCost;
    }

    public void SetHeuristicCost(int heuristicCost)
    {
        HeuristicCost = heuristicCost;
    }

    public void SetParent(Node parent)
    {
        Parent = parent;
    }

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