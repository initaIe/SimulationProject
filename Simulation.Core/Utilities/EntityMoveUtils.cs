using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;

namespace Simulation.Core.Utilities;
public static class EntityMoveUtils
{
    public static void MoveCreature(IMap map, ICreature creature, Node final)
    {
        map.UpdateLocation((IEntity)creature, final);
    }
}