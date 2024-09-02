namespace Simulation.Core.POCOs;

public class Node
{ 
    public Node(){}

    public Node(int x, int y)
    {
        X = x;
        Y = y;
    }
    public int X { get; }
    public int Y { get; } 
    public int DirectionCost { get; set; }
    public int HeuristicCost { get; set; }
    public int TotalCost => DirectionCost + HeuristicCost;
    public Node? Parent { get; set; }

    public override bool Equals(object? obj)
    {
        return obj is Node node && X == node.X && Y == node.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}