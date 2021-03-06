﻿using Mindden.Equipos.Application.DataService;
using Mindden.Equipos.Application.Response;

namespace Mindden.Equipos.Application.Interfaces
{
    public interface IEquipoService
    {
        
        /// <summary>
        /// Crear el equipo.
        /// </summary>
        /// <param name="DSEquipo">The ds equipo.</param>
        /// <returns></returns>
        CrearEquipoResponse CrearEquipo(DSEquipo dsEquipo);

        /// <summary>
        /// Obtener el equipo.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        ObtenerEquipoResponse ObtenerEquipo(int id);

        /// <summary>
        /// Actualizar el equipo.
        /// </summary>
        /// <param name="DSEquipo">The ds equipo.</param>
        /// <returns></returns>
        ActualizarEquipoResponse ActualizarEquipo(DSEquipo dsEquipo);

        /// <summary>
        /// Listar los equipos.
        /// </summary>
        /// <returns></returns>
        ListarEquiposResponse ListarEquipos();
        
        
    }
}