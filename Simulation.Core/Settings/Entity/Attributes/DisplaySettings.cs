namespace Simulation.Core.Settings.Entity.Attributes;

public class DisplaySettings(HashSet<string> sprites)
{
    public HashSet<string> Sprites { get; set; } = sprites;
}