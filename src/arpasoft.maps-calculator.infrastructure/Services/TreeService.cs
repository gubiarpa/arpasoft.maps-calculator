using arpasoft.maps_calculator.core.Behavior;
using arpasoft.maps_calculator.core.Entities;
using arpasoft.maps_calculator.core.Enums;
using arpasoft.maps_calculator.core.Services;

namespace arpasoft.maps_calculator.infrastructure.Services
{
    public class TreeService<T> where T : IEntityWithID
    {
        private readonly IMapService<T> _mapService;

        public TreeService(IMapService<T> mapService)
        {
            _mapService = mapService;
        }

        public TreeNode<T>? LoadTree(int idStart, int idEnd)
        {
            var nodes = _mapService.GetAllNodes();

            if (nodes == null)
                return null;

            var nodeStart = nodes!.SingleOrDefault(x => x.ID == idStart);

            if (nodeStart == null)
                return null;

            var _rootNode = new TreeNode<T>(nodeStart);

            if (_rootNode == null)
                return null;

            LoadNodeRecursively(idEnd, _rootNode);

            return _rootNode;
        }

        #region Utils
        private void LoadNodeRecursively(int searchedId, TreeNode<T> treeNode)
        {
            if (treeNode == null)
                return;

            if (treeNode.Data == null)
                return;

            var contacts = _mapService.GetAdjacentNodesByID(treeNode.Data.ID);

            if (contacts == null)
                return;

            foreach (var contact in contacts)
            {
                var childNode = new TreeNode<T>(contact, treeNode!);
                treeNode?.Children?.Add(childNode);
                childNode.State = SetState(searchedId, childNode);
                if (childNode.State == TreeNodeState.Active)
                    LoadNodeRecursively(searchedId, childNode);
            }
        }

        private TreeNodeState SetState(int searchedId, TreeNode<T> node)
        {
            if (node.Data?.ID == searchedId)
                return TreeNodeState.Matched;

            var nodeRun = node.Parent;

            while (nodeRun != null)
            {
                if (node.Data?.ID == nodeRun.Data?.ID)
                    return TreeNodeState.Loop;
                else
                    nodeRun = nodeRun.Parent;
            }

            return TreeNodeState.Active;
        }
        #endregion
    }
}
