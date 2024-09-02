using Simulation.Core.Interfaces;
using Simulation.Core.Settings;

namespace Simulation.Core.Actions;

public class EntityGenerateAction(SimulationSettings settings, IMap map)
{
    public void Perform()
    {
    }
    //todo
    public void GenerateEntity(Type type)
    {
        var rnd = new Random();

        var entitySettings = settings.Entities.GetEntitySettingsByType(type);

        var entity = Activator.CreateInstance(type);

        entity
    }
}