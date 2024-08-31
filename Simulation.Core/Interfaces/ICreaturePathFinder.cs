using Simulation.Core.POCO;

namespace Simulation.Core.Interfaces;
public interface ICreaturePathFinder
{
    List<Node> FindPath(Node start, Node final, HashSet<Node> barriers, int fieldWidth, int fieldHeight);
}
