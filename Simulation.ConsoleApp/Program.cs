using Simulation.Astar;
using Simulation.Core.Implementations;

var pathFinder = new AstarPathfinder();

var start = new Node(0, 0);
var final = new Node(10, 10);
HashSet<Node> barriers =
[
    new Node(3, 0),
    new Node(3, 1),
    new Node(1, 1),
    new Node(1, 2),
    new Node(5, 3),
    new Node(9, 3),
    new Node(2, 4),
    new Node(4, 4),
    new Node(5, 4),
    new Node(6, 4),
    new Node(7, 4),
    new Node(9, 4),
    new Node(9, 5),
    new Node(0, 6),
    new Node(5, 6),
    new Node(7, 6),
    new Node(9, 6),
    new Node(0, 7),
    new Node(2, 7),
    new Node(3, 7),
    new Node(5, 7),
    new Node(7, 7),
    new Node(0, 8),
    new Node(5, 8),
    new Node(9, 8),
    new Node(7, 9),
    new Node(7, 10),
    new Node(9, 10),
];
var result = pathFinder.FindPath(start, final, barriers, 11,11);

foreach (var path in result)
{
    Console.WriteLine("X = {0} Y = {1}", path.X, path.Y);
}

Console.ReadKey();