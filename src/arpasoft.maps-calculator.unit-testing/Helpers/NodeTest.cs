using arpasoft.maps_calculator.core.Behavior;

namespace arpasoft.maps_calculator.unit_testing.Helpers
{
    public class NodeTest : IEntityWithID
    {
        #region ID
        private int _id;
        public int ID => _id;

        public NodeTest(int id)
        {
            _id = id;
        }
        #endregion

        #region Data
        public string Name { get; set; }
        #endregion
    }
}
