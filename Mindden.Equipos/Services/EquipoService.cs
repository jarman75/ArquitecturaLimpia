using Mindden.Equipos.Core.Entities;
using Mindden.Equipos.Core.Entities.EquipoAggregate;
using Mindden.Equipos.Core.Interfaces;
using Mindden.Equipos.Services.DataService;
using Mindden.Equipos.Services.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using Mindden.Equipos.Services.Interfaces;

namespace Mindden.Equipos.Services
{
    public class EquipoService : IEquipoService
    {
                
        private readonly IEquipoRepository equipoRepository;
        
        /// <summary>
        /// Initializes a new instance of the <see cref="EquipoService"/> class.
        /// </summary>
        /// <param name="equipoRepository">The equipo repository.</param>
        public EquipoService(IEquipoRepository equipoRepository)
        {
            this.equipoRepository = equipoRepository;            
        }

        /// <summary>
        /// Crear el equipo.
        /// </summary>
        /// <param name="dsEquipo"></param>
        /// <returns></returns>
        public CrearEquipoResponse CrearEquipo(DSEquipo dsEquipo)
        {
            CrearEquipoResponse response = new CrearEquipoResponse(StatusEnum.NotProcessedOperation);

            try
            {
                //validacion equipo
                ValidacionDataEquipo(dsEquipo);

                Equipo equipo = new Equipo(dsEquipo.NombreEquipo, dsEquipo.Ubicacion, dsEquipo.Cliente);

                //agregar informatcios al equipo
                AgregarInformaticosAlEquipo(dsEquipo, equipo);

                this.equipoRepository.Add(equipo);

                response = new CrearEquipoResponse(StatusEnum.CorrectOperation,equipo.Id);

            }
            catch (ArgumentNullException ex)
            {
                response = new CrearEquipoResponse(StatusEnum.NullExcepcion, ex.Message);
            }
            catch (ArgumentException ex)
            {
                response = new CrearEquipoResponse(StatusEnum.ValidationError, ex.Message);
            }
            catch (Exception ex)
            {
                response = new CrearEquipoResponse(StatusEnum.UnKnownError, ex.Message);
            }

            return response;            
        }

        private static void ValidacionDataEquipo(DSEquipo dsEquipo)
        {
            if (dsEquipo == null) throw new ArgumentNullException(nameof(dsEquipo));
            if (string.IsNullOrWhiteSpace(dsEquipo.NombreEquipo)) throw new ArgumentException("Nombre no contiene valor", nameof(dsEquipo.NombreEquipo));
            if (string.IsNullOrWhiteSpace(dsEquipo.Ubicacion)) throw new ArgumentException("Provincia no contiene valor", nameof(dsEquipo.Ubicacion));
            if (string.IsNullOrWhiteSpace(dsEquipo.Cliente)) throw new ArgumentException("Cliente no contiene valor", nameof(dsEquipo.Cliente));
        }

        private static void AgregarInformaticosAlEquipo(DSEquipo dsEquipo, Equipo equipo)
        {
            foreach (var informatico in dsEquipo.Desarrolladores)
            {
                if (string.IsNullOrWhiteSpace(informatico.Nombre)) throw new ArgumentException("Nombre informatico no contiene valor", nameof(informatico.Nombre));
                if (string.IsNullOrWhiteSpace(informatico.Alias)) throw new ArgumentException("Alias informatico no contiene valor", nameof(informatico.Alias));

                equipo.AddDesarrolllador(new DesarrolladorEquipo(informatico.Nombre, informatico.Alias, informatico.Experiencia) );
            }
        }        

        /// <summary>
        /// Obtener el equipo.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        public ObtenerEquipoResponse ObtenerEquipo(int id)
        {
            ObtenerEquipoResponse response = new ObtenerEquipoResponse(StatusEnum.NotProcessedOperation);

            try
            {
                Equipo equipo = this.equipoRepository.GetById(id);

                if (equipo == null) throw new ArgumentException("Equipo no existe", nameof(id));
                
                List<DtoDesarrollador> informaticos = Mapper.Map<List<DtoDesarrollador>>(equipo.Desarrolladores);                
                
                DSEquipo dsEquipo = new DSEquipo(equipo.NombreEquipo, equipo.Ubicacion.Ubicacion, equipo.Ubicacion.Cliente, informaticos, equipo.Id);

                response = new ObtenerEquipoResponse(StatusEnum.CorrectOperation, string.Empty, dsEquipo);

            }
            catch (ArgumentException ex)
            {
                response = new ObtenerEquipoResponse(StatusEnum.OperationError, ex.Message);
            }

            catch (Exception ex)
            {

                response = new ObtenerEquipoResponse(StatusEnum.UnKnownError, ex.Message);              
            }

            return response;
        }        

        /// <summary>
        /// Actualizar el equipo.
        /// </summary>
        /// <param name="dsEquipo"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ActualizarEquipoResponse ActualizarEquipo(DSEquipo dsEquipo )
        {
            ActualizarEquipoResponse response = new ActualizarEquipoResponse(StatusEnum.NotProcessedOperation);

            try
            {

                Equipo equipo = this.equipoRepository.GetById(dsEquipo.Id);

                if (equipo == null) throw new ArgumentException("Equipo no existe", nameof(dsEquipo.Id));

                //validacion equipo
                ValidacionDataEquipo(dsEquipo);

                equipo.NombreEquipo = dsEquipo.NombreEquipo;
                equipo.SetUbicacion(dsEquipo.Ubicacion, dsEquipo.Cliente);

                equipo.RemoveAllDesarrolladores();

                ////añade desarrolladores del equipo modificado
                AgregarInformaticosAlEquipo(dsEquipo, equipo);

                equipoRepository.Update(equipo);

                response = new ActualizarEquipoResponse(StatusEnum.CorrectOperation);

            }
            catch (ArgumentException ex)
            {
                response = new ActualizarEquipoResponse(StatusEnum.OperationError, ex.Message);
            }
            catch (Exception ex)
            {
                response = new ActualizarEquipoResponse(StatusEnum.UnKnownError, ex.Message);
            }

            return response;
        }

        /// <summary>
        /// Listar los equipos.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ListarEquiposResponse ListarEquipos()
        {
            ListarEquiposResponse response = new ListarEquiposResponse(StatusEnum.NotProcessedOperation);
            
            try
            {
                
                List<Equipo> listaBasica = equipoRepository.GetBaseList().ToList();
                List<DtoBasicEquipo> equipos = new List<DtoBasicEquipo>();                                

                
                equipos = Mapper.Map<List<DtoBasicEquipo>>(listaBasica);
                
                
                response = new ListarEquiposResponse(StatusEnum.CorrectOperation, equipos);

            }
            catch (Exception ex)
            {
                response = new ListarEquiposResponse(StatusEnum.UnKnownError, ex.Message);

            }

            return response;

        }

       
    }
}
