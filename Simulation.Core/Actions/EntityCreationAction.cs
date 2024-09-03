using Simulation.Core.Entities;
using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.Settings;
using Simulation.Core.Settings.Entity.Implementations;
using Simulation.Core.Settings.Entity.Interfaces;

namespace Simulation.Core.Actions;

public class EntityGenerateAction(SimulationSettings settings, IMap map)
{
    private readonly Random _rnd = new();
    public void Perform()
    {
    }
    public IEntity GenerateEntity(Type type)
    {
        var entitySettings = settings.Entities.GetEntitySettingsByType(type);

        IEntity entity = entitySettings switch
        {
            StaticObjectSettings => GenerateStaticObject(entitySettings),
            FoodSettings => GenerateFood(entitySettings),
            HerbivoreSettings => GenerateHerbivore(entitySettings),
            PredatorSettings => GeneratePredator(entitySettings),
            _ => throw new ArgumentException("Invalid entity type")
        };

        return entity;
    }

    public StaticObject GenerateStaticObject(IEntitySettings entitySettings)
    {
        var staticObjectSettings = (StaticObjectSettings)entitySettings;

        string displayMark = staticObjectSettings.DisplayMark.DisplayMark;

        return new StaticObject(staticObjectSettings.DisplayMark.DisplayMark);
    }

    public Food GenerateFood(IEntitySettings entitySettings)
    {
        var foodSettings = (FoodSettings)entitySettings;

        int satiety = _rnd.Next(foodSettings.Satiety.MinSatiety, foodSettings.Satiety.MaxSatiety);

        return new Food(foodSettings.DisplayMark.DisplayMark, satiety);
    }

    public Herbivore GenerateHerbivore(IEntitySettings entitySettings)
    {
        var herbivoreSettings = (HerbivoreSettings)entitySettings;

        string displayMark = herbivoreSettings.DisplayMark.DisplayMark;
        int speed = _rnd.Next(herbivoreSettings.Speed.MinSpeed, herbivoreSettings.Speed.MaxSpeed);
        int health = _rnd.Next(herbivoreSettings.Health.MinHealth, herbivoreSettings.Health.MaxHealth);

        return new Herbivore(displayMark, speed, health);
    }

    public Predator GeneratePredator(IEntitySettings entitySettings)
    {
        var predatorSettings = (PredatorSettings)entitySettings;

        string displayMark = predatorSettings.DisplayMark.DisplayMark;
        int speed = _rnd.Next(predatorSettings.Speed.MinSpeed, predatorSettings.Speed.MaxSpeed);
        int health = _rnd.Next(predatorSettings.Health.MinHealth, predatorSettings.Health.MaxHealth);
        int damage = _rnd.Next(predatorSettings.Damage.MinDamage, predatorSettings.Damage.MaxDamage);

        return new Predator(displayMark, speed, health, damage);
    }
}