using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;

namespace Simulation.Core.Implementations;
/// <summary>
/// Класс отвечает за отрисовку поля в консоли.
/// </summary>
/// <param name="fieldSettings">Настройки поля (Ширина, высота).</param>
public class FieldConsoleRenderer(FieldSettings fieldSettings) : IFieldRender
{
    public void RenderCleanField()
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
    public void Render(HashSet<EntityRenderData> renderEntityData)
    {
        Console.Clear();
        RenderCleanField();
        foreach (var data in renderEntityData)
        {
            Console.SetCursorPosition(data.Node.X * 2, data.Node.Y);
            Console.Write(data.DisplayMark);
        }
    }
}