using Simulation.Core.Entities;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Implementations;

namespace Simulation.Core.Actions.CreationActions;
public class PredatorCreationAction : EntityCreationActionBase<Predator>
{
    protected override Predator CreateEntity(EntitiesSettings entitiesSettings)
    {
        var predatorSettings = (PredatorSettings)entitiesSettings.GetEntitySettingsByType(typeof(Predator));
        var sprite = GetRandomValue(predatorSettings.DisplaySettings.Sprites);
        var speed = GetRandomValueInLimits(predatorSettings.Speed);
        var health = GetRandomValueInLimits(predatorSettings.Health);
        var damage = GetRandomValueInLimits(predatorSettings.Damage);

        return new Predator(sprite, speed, health, damage);
    }
}