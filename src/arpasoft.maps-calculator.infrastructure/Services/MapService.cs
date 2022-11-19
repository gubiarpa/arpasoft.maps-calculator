using arpasoft.maps_calculator.core.Behavior;
using arpasoft.maps_calculator.core.Entities;
using arpasoft.maps_calculator.core.Services;

namespace arpasoft.maps_calculator.infrastructure.Services
{
    public class MapService<T> : IMapService<T> where T : IEntityWithID
    {
        public void AddConnection(int id1, int id2)
        {
            throw new NotImplementedException();
        }

        public void AddNode(T node)
        {
            throw new NotImplementedException();
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
    }
}
