using Simulation.Core.Interfaces;
using Simulation.Core.Interfaces.EntityInterfaces;
using Simulation.Core.POCO;
using Simulation.Core.Settings;

namespace Simulation.Core.Actions;

public class EntityGenerateAction<T>(IEntityLocationManager<Guid, Node> entityLocationManager, SimulationSettings simulationSettings) : IAction where T : IEntity
{
    public void Perform()
    {
    }
}