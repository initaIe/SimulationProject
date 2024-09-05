using Simulation.Core.Entities.Interfaces;
using Simulation.Core.Interfaces;
using Simulation.Core.PathFinding;
using Simulation.Core.Settings;

namespace Simulation.Core.Actions;
public abstract class TurnMoveCreatureActionBase<T> : IAction
    where T : ICreature
{
    public void Perform(IMap map, SimulationSettings simulationSettings)
    {
        throw new NotImplementedException();
    }
    public void MakeTurnMove(IMap map)
    {
    }

    public IEntity? GetClosestPrey(ICreature creature)
    {
        var creatureLocation = _map.GetEntityLocation(UpcastCreatureToEntity(creature));
        var barriers = GetBarriers();
        int minTotalCost = int.MaxValue;
        IEntity? closestPrey = null;

        foreach (var prey in GetPreys(creature))
        {
            var preyLocation = _map.GetEntityLocation(prey);
            var fieldSizeSettings = _simulationSettings.Field.SizeSettings;

            var path = AstarPathfinder.FindPath(
                creatureLocation,
                preyLocation,
                barriers,
                fieldSizeSettings.FieldWidth,
                fieldSizeSettings.FieldHeight);

            if (!path.Any()) continue;

            int totalCost = path[^1].TotalCost;

            if (totalCost < minTotalCost)
            {
                minTotalCost = totalCost;
                closestPrey = prey;
            }
        }
        return closestPrey;
    }

    public HashSet<Type> GetPreyTypesForEntity(T entity, EntitiesSettings entitiesSettings)
    {
        return entitiesSettings.GetEntitySettingsByType(T)
    }

    public HashSet<IEntity> GetPreys(IMap map, T entity, EntitiesSettings entitiesSettings)
    {
        return
        [
            .. GetPreyTypesForEntity(creature, entitiesSettings)
            .SelectMany(map.GetEntitesByType)
        ];
    }



}