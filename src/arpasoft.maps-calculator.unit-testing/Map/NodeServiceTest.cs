using arpasoft.maps_calculator.infrastructure.Services;
using arpasoft.maps_calculator.unit_testing.Helpers;

namespace arpasoft.maps_calculator.unit_testing.Map
{
    public class NodeServiceTest : MapService<NodeTest>
    {
        public override int GetNodeIdByValue(NodeTest data, int error)
        {
            throw new System.NotImplementedException();
        }
    }
}
