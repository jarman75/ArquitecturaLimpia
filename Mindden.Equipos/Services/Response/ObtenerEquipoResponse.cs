﻿using Mindden.Equipos.Services.DataService;

namespace Mindden.Equipos.Services.Response
{
    public class ObtenerEquipoResponse : BaseResponse
    {
        public ObtenerEquipoResponse(StatusEnum status) : base(status)
        {
        }

        public ObtenerEquipoResponse(StatusEnum status, string errorMessage) : base(status, errorMessage)
        {        
        }

        public ObtenerEquipoResponse(StatusEnum status, string errorMessage, DSEquipo equipo) : base(status, errorMessage)
        {
            this.Equipo = equipo;
        }

        public DSEquipo Equipo { get; private set; }
    }
}