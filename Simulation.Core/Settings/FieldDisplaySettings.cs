﻿namespace Simulation.Core.Settings;

public class FieldDisplaySettings(string emptyCellDisplayMark = "\ud83d\udfe9")
{
    public string EmptyCellDisplayMark { get; init; } = emptyCellDisplayMark;

}