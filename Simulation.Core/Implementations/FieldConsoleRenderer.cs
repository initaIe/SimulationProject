using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;

namespace Simulation.Core.Implementations;
public class FieldConsoleRenderer : IFieldRender
{
    public void RenderCleanField(FieldSettings fieldSettings)
    {
        for (int i = 0; i < fieldSettings.GetFieldHeight(); i++)
        {
            for (int j = 0; j < fieldSettings.GetFieldWidth(); j++)
            {
                Console.Write(fieldSettings.GetEmptyCellDisplayMark());
            }
            Console.WriteLine();
        }
    }

    // Эмодзи занимают 2 ед. по ширине, поэтому необходимо координату
    // по Х умножать на 2 для корректного отображения
    public void Render(FieldSettings fieldSettings, Dictionary<string, HashSet<Node>> spritePositions)
    {
        Console.Clear();
        RenderCleanField(fieldSettings);
        foreach (var sprite in spritePositions)
        {
            foreach (var location in sprite.Value)
            {
                Console.SetCursorPosition(location.X * 2, location.Y);
                Console.Write(sprite.Key);
            }
        }
        Console.SetCursorPosition(0, 0);
    }
}