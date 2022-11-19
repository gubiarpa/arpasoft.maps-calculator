using arpasoft.maps_calculator.core.Behavior;

namespace arpasoft.maps_calculator.core.Entities
{
    public class Map<T> where T : IEntityWithID
    {
        public List<T>? Nodes { get; set; }
        public List<Edge<T>>? Edges { get; set; }
    }
}
