using Xunit;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Mindden.Equipos.Infrastructure.Data;
using Mindden.Equipos.Configuration;
using Mindden.Equipos.Application.Services;
using Mindden.Equipos.Application.Response;
using Mindden.Equipos.Application.DataService;
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
            DSEquipo ds;
            CrearEquipoResponse responseCreate;

            //validate - exception operation
            TestValidateNullException(equipoService, informaticos, out ds, out responseCreate);

            //create correct operation            
            informaticos.Clear();
            informaticos.Add(new DtoDesarrollador("Alberto", "Llanero", 3));
            informaticos.Add(new DtoDesarrollador("Javi", "Trigo", 15));
            ds = new DSEquipo("ZeusTeam", "Alicante", "Suez", informaticos);
            responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.CorrectOperation);

            //get correct operation
            ObtenerEquipoResponse responseGet = equipoService.ObtenerEquipo(responseCreate.Id);
            Assert.True(responseGet.Status == StatusEnum.CorrectOperation);

            Assert.Equal(ds.NombreEquipo, responseGet.Equipo.NombreEquipo);
            Assert.Equal(ds.Ubicacion, responseGet.Equipo.Ubicacion);
            Assert.Equal(ds.Cliente, responseGet.Equipo.Cliente);

            //compara que los valores de las dos listas sean igual
            Assert.True(informaticos.SequenceEqual(responseGet.Equipo.Desarrolladores));

            informaticos.Add(new DtoDesarrollador("Jaime", "Kalimero", 1));
            ds = new DSEquipo("ZeusTeam2", "Alicante2", "Suez2", informaticos);

            //compara que los valores sean diferentes
            Assert.NotEqual(ds.NombreEquipo, responseGet.Equipo.NombreEquipo);
            Assert.NotEqual(ds.Ubicacion, responseGet.Equipo.Ubicacion);
            Assert.NotEqual(ds.Cliente, responseGet.Equipo.Cliente);

            //compara que los valores de las dos listas sean diferentes
            Assert.False(informaticos.SequenceEqual(responseGet.Equipo.Desarrolladores));

        }

        private static void TestValidateNullException(EquipoService equipoService, List<DtoDesarrollador> informaticos, out DSEquipo ds, out CrearEquipoResponse responseCreate)
        {
            //create nullError
            responseCreate = new CrearEquipoResponse(StatusEnum.NotProcessedOperation);
            responseCreate = equipoService.CrearEquipo(null);
            Assert.True(responseCreate.Status == StatusEnum.NullExcepcion);

            //create validationError
            ds = new DSEquipo("", "Alicante", "Suez", informaticos);
            responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.ValidationError);

            ds = new DSEquipo("ZeusTeam", "", "Suez", informaticos);
            responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.ValidationError);

            ds = new DSEquipo("ZeusTeam", "Alicante", "", informaticos);
            responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.ValidationError);

            
            //reglas entidad
            informaticos.Clear();
            // intruso
            informaticos.Add(new DtoDesarrollador("Intruso", "Chino", -1));
            informaticos.Add(new DtoDesarrollador("Javi", "Trigo", 15));
            ds = new DSEquipo("ZeusTeam", "Alicante", "Suez", informaticos);
            responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.ValidationError);
            // máximo 5
            informaticos.Clear();
            for (int i = 0; i < 10; i++)
            {
                informaticos.Add(new DtoDesarrollador("person" + i, "alias" + 1, 10));
            }                                        
            ds = new DSEquipo("ZeusTeam", "Alicante", "Suez", informaticos);
            responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.ValidationError);
            // becarios
            informaticos.Clear();            
            informaticos.Add(new DtoDesarrollador("becario1", "bec1", 0));
            informaticos.Add(new DtoDesarrollador("becario2", "bec2", 0));
            ds = new DSEquipo("ZeusTeam", "Alicante", "Suez", informaticos);
            responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.ValidationError);
        }

        [Fact]
        public void ListarEquiposTest()
        {
            var repository = GetRepository();
            EquipoService equipoService = new EquipoService(repository);

            List<DtoDesarrollador> informaticos = new List<DtoDesarrollador>();
            informaticos.Add(new DtoDesarrollador("Alberto", "Llanero", 3));
            informaticos.Add(new DtoDesarrollador("Javi", "Trigo", 15));

            //crear 10 equipos
            for (int i = 0; i < 10; i++)
            {
                DSEquipo ds = new DSEquipo("ZeusTeam_" + i, "Alicante_" + i, "Suez" + i, informaticos);
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
            informaticos.Add(new DtoDesarrollador("Alberto", "Llanero", 3));
            informaticos.Add(new DtoDesarrollador("Javi", "Trigo", 15));
            DSEquipo ds = new DSEquipo("ZeusTeam", "Alicante", "Suez", informaticos);

            //create
            CrearEquipoResponse responseCreate = equipoService.CrearEquipo(ds);
            Assert.True(responseCreate.Status == StatusEnum.CorrectOperation);


            //update
            informaticos.Clear();
            informaticos.Add(new DtoDesarrollador("Lucas","Pajaro",5));
            informaticos.Add(new DtoDesarrollador ("Carmen","Lara", 15 ));
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
            Assert.True(informaticos.SequenceEqual(responseGet.Equipo.Desarrolladores));

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