using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Mindden.Equipos.Infrastructure.Data;
using Mindden.Equipos.Infrastructure.Configuration;
using Mindden.Equipos.Services;
using Mindden.Equipos.Services.Response;
using Mindden.Equipos.Services.DataService;
using System.Linq;

namespace Mindden.Equipos.Tests.Services
{

    public class EquipoServiceTest
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
        public void CrearObtenerEquipoTest()
        {
            var repository = GetRepository();
            EquipoService equipoService = new EquipoService(repository);
            List<DtoDesarrollador> informaticos = new List<DtoDesarrollador>();            
            informaticos.Add(new DtoDesarrollador { Nombre = "Alberto", Alias = "Llanero", Experiencia = 3 });
            informaticos.Add(new DtoDesarrollador { Nombre = "Javi", Alias = "Trigo", Experiencia = 15 });

            DSEquipo ds = new DSEquipo("ZeusTeam", "Alicante", "Suez", informaticos);

            CrearEquipoResponse responseCreate = equipoService.CrearEquipo(ds);            
            Assert.True(responseCreate.Status == StatusEnum.CorrectOperation);


            ObtenerEquipoResponse responseGet = equipoService.ObtenerEquipo(responseCreate.Id);
            Assert.True(responseGet.Status == StatusEnum.CorrectOperation);

            //compara equipo
            Assert.Equal(ds.NombreEquipo, responseGet.Equipo.NombreEquipo);
            Assert.Equal(ds.Ubicacion, responseGet.Equipo.Ubicacion);
            Assert.Equal(ds.Cliente, responseGet.Equipo.Cliente);
            
            //compar que losvalores de las dos listas sean igual
            Assert.True(informaticos.SequenceEqual(ds.Desarrolladores));                          

        }

        [Fact]
        public void ListarEquiposTest()
        {
            var repository = GetRepository();
            EquipoService equipoService = new EquipoService(repository);

            List<DtoDesarrollador> informaticos = new List<DtoDesarrollador>();
            informaticos.Add(new DtoDesarrollador { Nombre = "Alberto", Alias = "Llanero", Experiencia = 3 });
            informaticos.Add(new DtoDesarrollador { Nombre = "Javi", Alias = "Trigo", Experiencia = 15 });

            //crear 10 equipos
            for (int i = 0; i < 10; i++)
            {
                DSEquipo ds = new DSEquipo("ZeusTeam_"+ i, "Alicante_"+i, "Suez"+i, informaticos);
                CrearEquipoResponse responseCreate = equipoService.CrearEquipo(ds);
                Assert.True(responseCreate.Status == StatusEnum.CorrectOperation);
            }

            ListarEquiposResponse responseListar = equipoService.ListarEquipos();

            Assert.True(responseListar.Status == StatusEnum.CorrectOperation);
            Assert.True(responseListar.Equipos.Count == 10);

        }

        [Fact]
        public void CrearActualizarEquipoTest()
        {
            var repository = GetRepository();

            EquipoService equipoService = new EquipoService(repository);

            List<DtoDesarrollador> informaticos = new List<DtoDesarrollador>();
            informaticos.Add(new DtoDesarrollador { Nombre = "Alberto", Alias = "Llanero", Experiencia = 3 });
            informaticos.Add(new DtoDesarrollador { Nombre = "Javi", Alias = "Trigo", Experiencia = 15 });
            DSEquipo ds = new DSEquipo("ZeusTeam", "Alicante", "Suez", informaticos);

            //create
            CrearEquipoResponse responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.CorrectOperation);


            //update
            informaticos.Clear();
            informaticos.Add(new DtoDesarrollador { Nombre = "Lucas", Alias = "Pajaro", Experiencia = 5 });
            informaticos.Add(new DtoDesarrollador { Nombre = "Carmen", Alias = "Lara", Experiencia = 15 });
            ds = new DSEquipo("RandomTeam", "Barcelona", "Repsol", informaticos, responseCreate.Id);

            ActualizarEquipoResponse responseUpdate = equipoService.ActualizarEquipo(ds);
            Assert.True(responseUpdate.Status == StatusEnum.CorrectOperation);

            //get
            ObtenerEquipoResponse responseGet = equipoService.ObtenerEquipo(responseCreate.Id);
            Assert.True(responseGet.Status == StatusEnum.CorrectOperation);
            
            //compara equipo
            Assert.Equal(ds.NombreEquipo, responseGet.Equipo.NombreEquipo);
            Assert.Equal(ds.Ubicacion, responseGet.Equipo.Ubicacion);
            Assert.Equal(ds.Cliente, responseGet.Equipo.Cliente);

            //compar que losvalores de las dos listas sean igual
            Assert.True(informaticos.SequenceEqual(ds.Desarrolladores));

        }

        private EquipoRepository GetRepository()
        {

            DataMap.Reset();
            DataMap.Register();

            var options = CreateNewContextOptions();

            _dbContext = new EquiposContext(options);
            return new EquipoRepository(_dbContext);
        }
        
    }
}