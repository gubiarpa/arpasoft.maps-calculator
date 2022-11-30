using arpasoft.maps_calculator.core.Behavior;

namespace arpasoft.maps_calculator.core.Services.Map
{
    public interface IMapEdgesService<T> where T : IEntityWithID
    {
        /// <summary>
        /// Devuelve el nodo (si existe), según el id especificado
        /// </summary>
        /// <param name="id">ID del nodo</param>
        /// <returns>El objeto</returns>
        /// <summary>
        /// Obtiene la lista de contactos de un nodo específico
        /// </summary>
        /// <param name="id">ID del Nodo a analizar</param>
        /// <returns>Lista de Contactos</returns>
        IEnumerable<T>? GetAdjacentNodesByID(int id);

        /// <summary>
        /// Devuelve true si existe la conexión
        /// </summary>
        /// <param name="id1">ID del Nodo 1</param>
        /// <param name="id2">ID del Nodo 2</param>
        /// <returns></returns>
        bool EdgeExists(int id1, int id2);

        /// <summary>
        /// Agrega una nueva conexión si es que no ésta no existe
        /// </summary>
        /// <param name="node1">ID del Nodo 1</param>
        /// <param name="node2">ID del Nodo 2</param>
        bool AddEdge(int id1, int id2);
    }
}
