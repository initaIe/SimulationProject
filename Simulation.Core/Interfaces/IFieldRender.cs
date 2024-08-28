using Simulation.Core.POCO;

namespace Simulation.Core.Interfaces;
public interface IFieldRender
{
    void Render(HashSet<EntityRenderData> renderEntityData);
}
