using arpasoft.maps_calculator.core.Behavior;
using arpasoft.maps_calculator.core.Services.Map;

namespace arpasoft.maps_calculator.core.Services
{
    public interface IMapService<T> :
        IMapNodesService<T>,
        IMapEdgesService<T>,
        IMapPathCalculateService<T>
            where T : IEntityWithID
    {
    }
}
