using Simulation.Astar;

var astar = new AstarPathfinder();
var startNode = new Node(0, 0);
var finalNode = new Node(5, 5);
HashSet<Node> barriers =
[
    new Node(0, 2),
    new Node(4, 1),
    new Node(4, 2),
    new Node(3, 2),
    new Node(2, 2),
    new Node(2, 3),
    new Node(2, 4),
];
var result = astar.FindPath(startNode, finalNode, barriers,6,6);

foreach (var t in result)
{
    Console.WriteLine("X = {0}, Y = {1}", t.X, t.Y);
}