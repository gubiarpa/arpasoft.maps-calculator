using arpasoft.maps_calculator.core.Behavior;
using arpasoft.maps_calculator.core.Entities;
using arpasoft.maps_calculator.core.Services;

namespace arpasoft.maps_calculator.infrastructure.Services
{
    public class MapService<T> : IMapService<T> where T : IEntityWithID
    {
        private readonly Map<T> _map;

        public MapService()
        {
            _map = new Map<T>()
            {
                Nodes = new List<T>(),
                Edges = new List<Edge<T>>()
            };
        }

        public void AddConnection(int id1, int id2)
        {
        }

        public void AddNode(T node)
        {
            if (!IsValidMap())
                return;

            _map!.Nodes!.Add(node);
        }

        public bool ConnectionExists(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T>? GetContacts(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T>? GetNodes()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TreeNode<T>>? GetPaths(int idStart, int idEnd)
        {
            throw new NotImplementedException();
        }

        public int NodesCount()
        {
            throw new NotImplementedException();
        }

        #region Utils
        private bool IsValidMap()
        {
            if (_map == null)
                return false;

            if (_map.Nodes == null)
                return false;

            if (_map.Edges == null)
                return false;

            return true;
        }
        #endregion
    }
}
