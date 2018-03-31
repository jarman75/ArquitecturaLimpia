using Mindden.Equipos.Core.Entities;
using Mindden.Equipos.Core.Entities.EquipoAggregate;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mindden.Equipos.Core.Interfaces
{

    public interface IEquipoRepository : IRepository<Equipo>, IAsyncRepository<Equipo>
    {
                        
        /// <summary>
        /// Gets the by identifier with items.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Equipo GetByIdWithItems(int id);

        /// <summary>
        /// Gets the by identifier with items asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        Task<Equipo> GetByIdWithItemsAsync(int id);

        /// <summary>
        /// Lists the basic.
        /// </summary>
        /// <returns></returns>
        ICollection<BaseEquipo> ListBasic(); 
    }
}
