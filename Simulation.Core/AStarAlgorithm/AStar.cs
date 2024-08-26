namespace Simulation.Core.AStarAlgorithm;

public class AStar
{
    public List<Node>? FindPath(Node start, Node final, List<Node> barriers)
    {
        var openSet = new List<Node> { start };
        var closedSet = new HashSet<Node>();

        while (openSet.Count > 0)
        {
            Node currentNode = openSet[0];

            for (int i = 1; i < openSet.Count; i++)
            {
                if (openSet[i].TotalWeight < currentNode.TotalWeight ||
                   (openSet[i].TotalWeight == currentNode.TotalWeight &&
                    openSet[i].HeuristicCost < currentNode.HeuristicCost))
                {
                    currentNode = openSet[i];
                }
            }

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if (currentNode.X == final.X && currentNode.Y == final.Y)
            {
                return AstarUtility.GetNodePath(start, currentNode);
            }

            foreach (var neighbor in AstarUtility.GetNeighbors(currentNode))
            {
                if (closedSet.Contains(neighbor) || barriers.Contains(neighbor))
                {
                    continue;
                }

                int movementCost = (currentNode.X != neighbor.X && currentNode.Y != neighbor.Y)
                    ? (int)MovementCost.Diagonal : (int)MovementCost.Orthogonal;

                int newCostToNeighbor = currentNode.DirectionCost + movementCost;

                if (newCostToNeighbor < neighbor.DirectionCost || !openSet.Contains(neighbor))
                {
                    neighbor.SetDirectionCost(newCostToNeighbor);
                    int newHeuristicPrice = AstarUtility.GetHeuristicPrice(neighbor, final);
                    neighbor.SetHeuristicCost(newHeuristicPrice);
                    neighbor.SetParent(currentNode);

                    if (!openSet.Contains(neighbor))
                    {
                        openSet.Add(neighbor);
                    }
                }
            }
        }

        return null;
    }
}
