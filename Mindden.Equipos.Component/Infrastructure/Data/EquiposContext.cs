using Mindden.Equipos.Core.Entities.EquipoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Runtime.CompilerServices;


[assembly: InternalsVisibleTo("Mindden.Equipos.Tests")]
namespace Mindden.Equipos.Infrastructure.Data
{
    internal class EquiposContext: DbContext
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="EquiposContext"/> class.
        /// </summary>
        /// <param name="options">The options.</param>
        public EquiposContext(DbContextOptions<EquiposContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        /// <summary>
        /// Gets or sets the equipos.
        /// </summary>
        /// <value>
        /// The equipos.
        /// </value>
        public DbSet<Equipo> Equipos { get; set; }

        /// <summary>
        /// Called when [model creating].
        /// </summary>
        /// <param name="builder">The builder.</param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Equipo>(ConfigureEquipo);            
        }        

        /// <summary>
        /// Configures the equipo.
        /// </summary>
        /// <param name="builder">The builder.</param>
        private void ConfigureEquipo(EntityTypeBuilder<Equipo> builder)
        {
            var navigation = builder.Metadata.FindNavigation(nameof(Equipo.Desarrolladores));

            navigation.SetPropertyAccessMode(PropertyAccessMode.Field);

            builder.OwnsOne(o => o.Ubicacion);            

        }
    }
}