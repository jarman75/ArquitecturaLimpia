using Mindden.Equipos.Core.Entities;
using System.Collections.Generic;

namespace Mindden.Equipos.Core.Interfaces
{
    public interface IEquipoQuery
    {
        ICollection<BaseEntity> ListDesarrolladores();
    }
}
