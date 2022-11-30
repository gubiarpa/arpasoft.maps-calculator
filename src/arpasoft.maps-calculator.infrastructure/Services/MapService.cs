using arpasoft.maps_calculator.core.Behavior;
using arpasoft.maps_calculator.core.Entities;
using arpasoft.maps_calculator.core.Services;

namespace arpasoft.maps_calculator.infrastructure.Services
{
    public abstract class MapService<T> : IMapService<T> where T : IEntityWithID
    {
        #region Map
        private readonly Map<T> _map;

        public MapService()
        {
            _map = new Map<T>()
            {
                Nodes = new List<T>(),
                Edges = new List<Edge<T>>()
            };
        }
        #endregion

        #region Node
        public void AddNode(T node)
        {
            if (!IsValidMap())
                return;

            _map!.Nodes!.Add(node);
        }

        public IEnumerable<T>? GetAllNodes()
        {
            return _map?.Nodes;
        }

        public int GetNodesCount()
        {
            if (!IsValidMap())
                return 0;

            return _map!.Nodes!.Count;
        }

        public abstract T? GetNodeByValue(T data);
        #endregion

        #region Edge
        public bool AddEdge(int id1, int id2)
        {
            if (!IsValidMap())
                return false;

            if (id1 == id2)
                return false;

            if (EdgeExists(id1, id2))
                return false;

            var node1 = _map!.Nodes!.SingleOrDefault(x => x.ID == id1);
            var node2 = _map!.Nodes!.SingleOrDefault(x => x.ID == id2);

            if (node1 == null || node2 == null)
                return false;

            var edge = new Edge<T>()
            {
                NodeStart = node1,
                NodeEnd = node2
            };

            _map.Edges!.Add(edge);

            return true;
        }

        public bool EdgeExists(int id1, int id2)
        {
            if (!IsValidMap())
                return false;

            var connectionExists = _map.Edges!.Any(x => x.NodeStart!.ID == id1 && x.NodeEnd!.ID == id2);

            return connectionExists;
        }
        #endregion

        #region Calculation
        public IEnumerable<T>? GetAdjacentNodesByID(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TreeNode<T>>? GetPaths(int idStart, int idEnd)
        {
            throw new NotImplementedException();
        }
        #endregion

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
