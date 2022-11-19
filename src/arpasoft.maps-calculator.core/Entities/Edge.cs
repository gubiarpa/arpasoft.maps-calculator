using arpasoft.maps_calculator.core.Behavior;

namespace arpasoft.maps_calculator.core.Entities
{
    public class Edge<T> where T : IEntityWithID
    {
        public T? NodeStart { get; set; }
        public T? NodeEnd { get; set; }
        public float Length { get; set; }
        public float Weight { get; set; }
    }
}
