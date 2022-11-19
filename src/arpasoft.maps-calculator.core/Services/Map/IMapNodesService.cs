using arpasoft.maps_calculator.core.Behavior;

namespace arpasoft.maps_calculator.core.Services.Map
{
    public interface IMapNodesService<T> where T : IEntityWithID
    {
        void AddNode(T node);
        IEnumerable<T>? GetAllNodes();
        public int GetNodesCount();
    }
}
