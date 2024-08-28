using Simulation.Core.Interfaces;
using Simulation.Core.Interfaces.EntityInterfaces;
using Simulation.Core.Settings;

namespace Simulation.Core.Actions;

public class EntityGenerateAction<T>(IMap map, SimulationSettings simulationSettings) : IAction where T : IEntity
{

    public void Perform()
    {
        var eSettings = simulationSettings.EntitiesSettings;

        eSettings.
    }
}