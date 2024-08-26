using Simulation.Core.AStarAlgorithm;

namespace Simulation.Core.Interfaces;
public interface IFieldRender
{
    public void RenderField(Dictionary<Node, string> coordinateDisplayMarks);
}
