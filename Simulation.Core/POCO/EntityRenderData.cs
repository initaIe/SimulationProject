namespace Simulation.Core.POCO;

public class EntityRenderData(string displayMark, Node node)
{
    public string DisplayMark { get; init; } = displayMark;
    public Node Node { get; init; } = node;

    // Надо ли оно мне????
    //public override bool Equals(object? obj)
    //{
    //    if (obj is null) throw new ArgumentException("Некорректное значение параметра");
    //    return obj is EntityRenderData renderEntityData &&
    //           DisplayMark == renderEntityData.DisplayMark &&
    //           Node.X == renderEntityData.Node.X &&
    //           Node.Y == renderEntityData.Node.Y;
    //}

    //public override int GetHashCode()
    //{
    //    return HashCode.Combine(DisplayMark, Node.X, Node.Y);
    //}
}