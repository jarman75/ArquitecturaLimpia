using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Mindden.Equipos.Core.Entities;
using Mindden.Equipos.Core.Interfaces;

[assembly: InternalsVisibleTo("Mindden.Equipos.Tests")]
namespace Mindden.Equipos.Infrastructure.Data
{
    internal class EquipoQuerys: IEquipoQuery 
    {
        /// <summary>
        /// The database context
        /// </summary>
        protected readonly EquiposContext _dbContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="EfRepository{T}"/> class.
        /// </summary>
        /// <param name="dbContext">The database context.</param>
        public EquipoQuerys(EquiposContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ICollection<BaseEntity> ListDesarrolladores()
        {
            throw new System.NotImplementedException();
        }
    }
}
