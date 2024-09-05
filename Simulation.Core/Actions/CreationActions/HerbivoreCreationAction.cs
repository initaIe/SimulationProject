using Simulation.Core.Entities;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Implementations;

namespace Simulation.Core.Actions.CreationActions;

public class HerbivoreCreationAction : EntityCreationActionBase<Herbivore>
{
    protected override Herbivore CreateEntity(EntitiesSettings entitiesSettings)
    {
        var herbivoreSettings = (HerbivoreSettings)entitiesSettings.GetEntitySettingsByType(typeof(Herbivore));
        var sprite = GetRandomValue(herbivoreSettings.DisplaySettings.Sprites);
        var speed = GetRandomValueInLimits(herbivoreSettings.Speed);
        var health = GetRandomValueInLimits(herbivoreSettings.Health);

        return new Herbivore(sprite, speed, health);
    }
}