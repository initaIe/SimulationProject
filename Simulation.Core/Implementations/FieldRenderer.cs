using Simulation.Core.AStarAlgorithm;
using Simulation.Core.Interfaces;

namespace Simulation.Core.Implementations;
public class FieldRenderer(int fieldWidth, int fieldHeight) : IFieldRender
{
    private List<List<string>> CreateCleanField()
    {
        var field = new List<List<string>>();
        for (int i = 0; i < fieldHeight; i++)
        {
            var row = new List<string>();
            for (int j = 0; j < fieldWidth; j++)
            {
                row.Add("\ud83d\udfe9");
            }
            field.Add(row);
        }
        return field;
    }

    private List<List<string>> CreateFieldWithEntities(Dictionary<Node, string> coordinateDisplayMarks)
    {
        var field = CreateCleanField();

        foreach (var item in coordinateDisplayMarks)
        {
            field[item.Key.X][item.Key.Y] = item.Value;
        }
        return field;
    }

    public void RenderField(Dictionary<Node, string> coordinateDisplayMarks)
    {
        var fieldWithEntities = CreateFieldWithEntities(coordinateDisplayMarks);

        foreach (var innerList in fieldWithEntities)
        {
            Console.WriteLine(string.Join("", innerList));
        }
    }
}