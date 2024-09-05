using Simulation.Core.Entities;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Implementations;

namespace Simulation.Core.Actions.CreationActions;
public class FoodCreationAction : EntityCreationActionBase<Food>
{
    protected override Food CreateEntity(EntitiesSettings entitiesSettings)
    {
        var foodSettings = (FoodSettings)entitiesSettings.GetEntitySettingsByType(typeof(Food));
        var sprite = GetRandomValue(foodSettings.DisplaySettings.Sprites);
        var satiety = GetRandomValueInLimits(foodSettings.Satiety);

        return new Food(sprite, satiety);
    }
}
