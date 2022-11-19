using arpasoft.maps_calculator.core.Behavior;
using arpasoft.maps_calculator.core.Entities;

namespace arpasoft.maps_calculator.core.Services.Map
{
    public interface IMapPathCalculateService<T> where T : IEntityWithID
    {
        IEnumerable<TreeNode<T>>? GetPaths(int idStart, int idEnd);
    }
}
