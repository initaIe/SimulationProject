using Simulation.Core.POCOs;
using Simulation.Core.Settings;

namespace Simulation.Core.Interfaces
{
    public interface IFieldRender
    {
        void Render(FieldSettings fieldSettings, Dictionary<string, HashSet<Node>> spritePositions);
    }
}