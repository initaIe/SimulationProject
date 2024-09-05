namespace Simulation.Core.POCOs;

public class EntityRenderData(string displayMark, Node node)
{
    public string DisplayMark { get; init; } = displayMark;
    public Node Node { get; init; } = node;

    public override bool Equals(object? obj)
    {
        return obj is EntityRenderData renderEntityData &&
               Node.X == renderEntityData.Node.X &&
               Node.Y == renderEntityData.Node.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Node.X, Node.Y);
    }
}