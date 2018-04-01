using Mindden.Equipos.Core.Entities;
using Mindden.Equipos.Core.Interfaces;
using Mindden.Equipos.Services.DataService;
using Mindden.Equipos.Services.Interfaces;
using System.Collections.Generic;

namespace Mindden.Equipos.Services
{
    public class EquipoServiceQuery: IEquipoServiceQuery
    {
        private IEquipoQuery _equipoQuerys;

        public EquipoServiceQuery(IEquipoQuery equipoQuerys)
        {
            _equipoQuerys = equipoQuerys;
        }

        public ICollection<BaseEntity> ListarDesarrolladores()
        {
            return _equipoQuerys.ListDesarrolladores();
        }

        
    }
}
