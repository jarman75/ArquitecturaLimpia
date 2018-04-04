using System;
using Xunit;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Mindden.Equipos.Core.Entities.EquipoAggregate;
using Mindden.Equipos.Infrastructure.Data;


namespace Mindden.Equipos.Tests.Infrastructure
{
    public class EfRepositoryTest
    {
        private EquiposContext _dbContext;

        private static DbContextOptions<EquiposContext> CreateNewContextOptions()
        {
            // Crea proveedor de servicio 
            // instancia base de datos en memoria.
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();


            // Crea instancia pasando opciones al contexto a usar
            // para base de datos en memoria y al nuevo proveedor de servicio
            var builder = new DbContextOptionsBuilder<EquiposContext>();
            builder.UseInMemoryDatabase("ZeusTeam")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        [Fact]
        public void AddEquipoAndSetId()
        {
            var repository = GetRepository();
            var equipo = new Equipo("DreamTeam", "Alicante", "Suez");
            equipo.AddDesarrolllador(new DesarrolladorEquipo("desarrollador1", "baby", 1));

            repository.Add(equipo);

            var newEquipo = repository.ListAll().FirstOrDefault();

            Assert.Equal(equipo, newEquipo);
            Assert.True(newEquipo.Id > 0);

        }

        [Fact]
        public void UpdateEquipoAfterAddingIt()
        {
            // crea un equipo
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var equipo = new Equipo(initialName, "Alicante", "Suez");

            repository.Add(equipo);

            // detach the team so we get a different instance
            _dbContext.Entry(equipo).State = EntityState.Detached;

            // cambia el nombre
            var newEquipo = repository.ListAll()
                .FirstOrDefault(i => i.NombreEquipo == initialName);
            Assert.NotSame(equipo, newEquipo);
            var newName = Guid.NewGuid().ToString();
            newEquipo.NombreEquipo = newName;

            // actualiza el equipo
            repository.Update(newEquipo);
            var updatedEquipo = repository.ListAll()
                .FirstOrDefault(i => i.NombreEquipo == newName);

            Assert.NotEqual(equipo.NombreEquipo, updatedEquipo.NombreEquipo);
            Assert.Equal(newEquipo.Id, updatedEquipo.Id);
        }

        [Fact]
        public void DeleteEquipoAfterAddingIt()
        {
            // añade un equipo
            var repository = GetRepository();
            var initialName = Guid.NewGuid().ToString();
            var equipo = new Equipo(initialName,"Alicante","Suez");
            repository.Add(equipo);

            // borra el equipo
            repository.Delete(equipo);

            // verifica que el repositorio está vacio
            Assert.DoesNotContain(repository.ListAll(),
                i => i.NombreEquipo == initialName);
        }



        private EfRepository<Equipo> GetRepository()
        {
            var options = CreateNewContextOptions();            

            _dbContext = new EquiposContext(options);
            return new EfRepository<Equipo>(_dbContext);
        }
    }
}
