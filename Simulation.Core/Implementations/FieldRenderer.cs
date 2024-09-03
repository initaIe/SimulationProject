﻿using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;
using Simulation.Core.Settings;

namespace Simulation.Core.Implementations;
/// <summary>
/// Класс отвечает за отрисовку поля в консоли.
/// </summary>
/// <param name="fieldSettings">Настройки поля (Ширина, высота).</param>
public class FieldRenderer(FieldSettings fieldSettings) : IFieldRender
{
    public void RenderCleanField()
    {
        for (int i = 0; i < fieldSettings.SizeSettings.FieldHeight; i++)
        {
            for (int j = 0; j < fieldSettings.SizeSettings.FieldWidth; j++)
            {
                Console.Write(fieldSettings.DisplaySettings.EmptyCellDisplayMark);
            }
            Console.WriteLine();
        }
    }

    // Эмодзи занимают 2 ед. по ширине, поэтому необходимо координату
    // по Х умножать на 2 для корректного отображения
    public void Render(HashSet<EntityRenderData> renderEntityData)
    {
        RenderCleanField();
        foreach (var data in renderEntityData)
        {
            Console.SetCursorPosition(data.Node.X * 2, data.Node.Y);
            Console.Write(data.DisplayMark);
        }
    }
}