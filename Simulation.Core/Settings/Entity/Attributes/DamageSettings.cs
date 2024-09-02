namespace Simulation.Core.Settings.Entity.Attributes;

public class DamageSettings(int minDamage, int maxDamage)
{
    public int MinDamage { get; set; } = minDamage;
    public int MaxDamage { get; set; } = maxDamage;
}
