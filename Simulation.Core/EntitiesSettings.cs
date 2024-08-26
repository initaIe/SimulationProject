using Simulation.Core.Implementations.EntityImplementations;

namespace Simulation.Core;

public class EntitiesSettings
{
    private readonly Dictionary<Type, (int Min, int Max)> _entitiesLimit = new()
    {
        { typeof(StaticObject), (5, 10) },
        { typeof(Herbivore), (2, 5) },
        { typeof(Predator), (1, 2) },
        { typeof(Food), (5, 10) }
    };

    public void SetLimits(Type type, int min, int max)
    {
        if (_entitiesLimit.ContainsKey(type))
        {
            if (min < 0 || max < min)
                throw new ArgumentException("Invalid limits.");

            _entitiesLimit[type] = (min, max);
        }
        else
        {
            throw new ArgumentException("Unknown type.");
        }
    }

    public (int Min, int Max) GetLimits(Type type)
    {
        if (_entitiesLimit.TryGetValue(type, out var limits))
        {
            return limits;
        }
        throw new ArgumentException("Unknown object type.");
    }
}
