using arpasoft.maps_calculator.infrastructure.Services;
using arpasoft.maps_calculator.winforms.Utils;

namespace arpasoft.maps_calculator.winforms.Map
{
    public class MapCoordinateService : MapService<Coordinate>
    {
        private int _errorX;
        private int _errorY;

        public MapCoordinateService(int errorX, int errorY) : base()
        {
            _errorX = errorX;
            _errorY = errorY;
        }

        public override Coordinate? GetNodeByValue(Coordinate data)
        {
            var matchNode = GetAllNodes()?.FirstOrDefault(node => node.IsNear(data, _errorX, _errorY));
            return matchNode;
        }
    }
}
