namespace Simulation.Core.Settings.Entity.Attributes;

public class HealthSettings(int minHealth, int maxHealth)
{
    public int MinHealth { get; set; } = minHealth;
    public int MaxHealth { get; set; } = maxHealth;
}
