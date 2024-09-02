namespace Simulation.Core.Settings.Entity.Attributes;

public class SpeedSettings(int minSpeed, int maxSpeed)
{
    public int MinSpeed { get; set; } = minSpeed;
    public int MaxSpeed { get; set; } = maxSpeed;
}