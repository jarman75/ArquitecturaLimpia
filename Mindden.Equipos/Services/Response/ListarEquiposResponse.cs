using Mindden.Equipos.Services.DataService;
using System.Collections.Generic;

namespace Mindden.Equipos.Services.Response
{
    public class ListarEquiposResponse : BaseResponse
    {
        public ListarEquiposResponse(StatusEnum status) : base(status)
        {
        }

        public ListarEquiposResponse(StatusEnum status, string errorMessage) : base(status, errorMessage)
        {
        }

        public ListarEquiposResponse(StatusEnum status, List<DtoBasicEquipo> equipos ) : base(status)
        {
            this._equipos = equipos;
        }

        private List<DtoBasicEquipo> _equipos; 

        public List<DtoBasicEquipo> Equipos
        {
            get
            {
                return this._equipos;
            }
        }
    }
}