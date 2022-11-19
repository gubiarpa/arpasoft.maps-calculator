using arpasoft.maps_calculator.core.Services;
using arpasoft.maps_calculator.unit_testing.Helpers;
using System.Linq;
using Xunit;

namespace arpasoft.maps_calculator.unit_testing.Map
{
    public class MapServiceTest
    {
        private readonly IMapService<NodeTest> _mapService;

        public MapServiceTest()
        {
            _mapService = new NodeServiceTest();
        }

        [Fact]
        public void ShouldAddNodes()
        {
            /// Arrange
            _mapService.AddNode(new NodeTest(1) { Name = "Bulbasaur" });
            _mapService.AddNode(new NodeTest(2) { Name = "Ivisaur" });
            _mapService.AddNode(new NodeTest(3) { Name = "Venasaur" });
            _mapService.AddNode(new NodeTest(4) { Name = "Charmander" });
            _mapService.AddNode(new NodeTest(5) { Name = "Charmeleon" });
            _mapService.AddNode(new NodeTest(6) { Name = "Charizard" });

            /// Act
            var countNodes = _mapService.GetNodes()?.ToList().Count;
            
            /// Assert
            Assert.Equal(6, countNodes);
        }
    }
}
