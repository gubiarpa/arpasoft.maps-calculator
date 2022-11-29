using arpasoft.maps_calculator.core.Behavior;

namespace arpasoft.maps_calculator.winforms.Utils
{
    public class Coordinate : IEntityWithID
    {
        #region ID
        private int _id;
        public int ID => _id;

        public Coordinate(int id)
        {
            _id = id;
        }
        #endregion

        #region Data
        public int X { get; set; }
        public int Y { get; set; }
        #endregion

        #region Methods
        public bool IsNear(Coordinate coordinate, int error)
        {
            return (Math.Abs(X - coordinate.X) <= error && Math.Abs(Y - coordinate.Y) <= error);
        }
        #endregion
    }
}
