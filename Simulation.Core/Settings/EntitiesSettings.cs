namespace Simulation.Core.Settings;

public class EntitiesSettings(
    EntitiesSpeedSettings speedSettings,
    EntitiesDamageSettings damageSetting,
    EntitiesHealthSettings healthSetting,
    EntitiesSatietySettings satietySetting,
    EntitiesDisplaySettings displaySettings,
    EntitiesPercentAreaSettings percentAreaSettings)
{
    public EntitiesSpeedSettings SpeedSettings { get; init; } = speedSettings;
    public EntitiesDamageSettings DamageSetting { get; init; } = damageSetting;
    public EntitiesHealthSettings HealthSetting { get; init; } = healthSetting;
    public EntitiesSatietySettings SatietySetting { get; init; } = satietySetting;
    public EntitiesDisplaySettings DisplaySettings { get; init; } = displaySettings;
    public EntitiesPercentAreaSettings PercentAreaSettings { get; init; } = percentAreaSettings;
}
