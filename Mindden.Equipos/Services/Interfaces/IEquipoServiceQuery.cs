using Mindden.Equipos.Core.Entities;
using System.Collections.Generic;

namespace Mindden.Equipos.Services.Interfaces
{
    public interface IEquipoServiceQuery
    {
        ICollection<BaseEntity> ListarDesarrolladores();
    }
}
