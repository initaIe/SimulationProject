using Simulation.Core.Settings.Entity;

namespace Simulation.Core.Settings;

public class EntitiesSettings(
    Speed speed,
    Damage damage,
    Health health,
    Satiety satiety,
    Display display,
    PercentArea percentArea,
    Target target)
{
    public Speed Speed { get; init; } = speed;
    public Damage Damage { get; init; } = damage;
    public Health Health { get; init; } = health;
    public Satiety Satiety { get; init; } = satiety;
    public Display Display { get; init; } = display;
    public PercentArea PercentArea { get; init; } = percentArea;
    public Target Target { get; init; } = target;
}
