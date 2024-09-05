using Simulation.Core.Interfaces;
using Simulation.Core.POCOs;

namespace Simulation.Core.Utilities;
public static class ConsoleRenderUtils
{
    public static Dictionary<string, HashSet<Node>> GetRenderEntityData(IMap map)
    {
        Dictionary<string, HashSet<Node>> spritesPositions = [];

        var entities = map.GetEntities();

        foreach (var entity in entities)
        {
            var sprite = entity.Sprite;
            var coordinate = map.GetEntityLocation(entity);

            if (!spritesPositions.ContainsKey(sprite))
            {
                spritesPositions.Add(sprite, []);
            }

            spritesPositions[sprite].Add(coordinate);
        }

        return spritesPositions;
    }
}
