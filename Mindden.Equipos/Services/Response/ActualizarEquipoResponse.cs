﻿namespace Mindden.Equipos.Services.Response
{
    public class ActualizarEquipoResponse : BaseResponse
    {
        public ActualizarEquipoResponse(StatusEnum status) : base(status)
        {
        }

        public ActualizarEquipoResponse(StatusEnum status, string errorMessage) : base(status, errorMessage)
        {
        }
    }
}