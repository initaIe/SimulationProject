namespace Simulation.Core.Implementations;

public class EntityRenderData(string displayMark, Node node)
{
    public string DisplayMark { get; init; } = displayMark;
    public Node Node { get; init; } = node;

    public override bool Equals(object? obj)
    {
        return obj is EntityRenderData renderEntityData &&
               DisplayMark == renderEntityData.DisplayMark &&
               Node.X == renderEntityData.Node.X &&
               Node.Y == renderEntityData.Node.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(DisplayMark, Node.X, Node.Y);
    }
}
