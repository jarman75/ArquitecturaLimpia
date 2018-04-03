using Mindden.Equipos.Core.Entities.EquipoAggregate;
using Mindden.Equipos.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Mindden.Equipos.Tests")]
namespace Mindden.Equipos.Infrastructure.Data
{
    internal class EquipoRepository : EfRepository<Equipo>, IEquipoRepository
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EquipoRepository"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EquipoRepository(EquiposContext dbContext) : base(dbContext)
        {
        }

        /// <summary>
        /// Gets the by identifier with items.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Equipo GetByIdWithItems(int id)
        {
            return _dbContext.Equipos
                .Include(o => o.Desarrolladores)                                
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the by identifier with items asynchronous.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public Task<Equipo> GetByIdWithItemsAsync(int id)
        {
            return _dbContext.Equipos
                .Include(o => o.Desarrolladores)                
                .FirstOrDefaultAsync();
        }

        public ICollection<Equipo> GetBaseList()
        {
            return _dbContext.Equipos
                .Select(e => new Equipo { Id = e.Id, NombreEquipo = e.NombreEquipo })                
                .OrderBy(e => e.Id).ToList();
        }

        public async Task<ICollection<Equipo>> GetBaseListAsync()
        {
            var result = _dbContext.Equipos
                .Select(e => new Equipo { Id = e.Id, NombreEquipo = e.NombreEquipo })
                .OrderBy(e => e.Id);

            return await result
                .ToListAsync();
                
        }
    }
}
