using Simulation.Core.Entities;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Implementations;

namespace Simulation.Core.Actions.CreationActions;
public class StaticObjectCreationAction : EntityCreationActionBase<StaticObject>
{
    protected override StaticObject CreateEntity(EntitiesSettings entitiesSettings)
    {
        var staticObjectSettings = (StaticObjectSettings)entitiesSettings.GetEntitySettingsByType(typeof(StaticObject));
        var sprite = GetRandomValue(staticObjectSettings.DisplaySettings.Sprites);

        return new StaticObject(sprite);
    }
}