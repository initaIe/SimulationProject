using Simulation.Core.POCOs;

namespace Simulation.Core.Interfaces
{
    public interface IFieldRender
    {
        void Render(HashSet<EntityRenderData> renderEntityData);
    }
}