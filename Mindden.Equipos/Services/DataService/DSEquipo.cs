using Mindden.Equipos.Core.Common;
using Mindden.Equipos.Core.Entities.EquipoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mindden.Equipos.Services.DataService
{
    public class DSEquipo : ValueObject
    {
        private readonly ICollection<DtoDesarrollador> _desarrolladores;               

        public DSEquipo(string nombreEquipo, string ubicacion, string cliente, ICollection<DtoDesarrollador> desarrolladores, int id = 0)
        {            
            Id = id;
            NombreEquipo = nombreEquipo;
            Ubicacion = ubicacion;
            Cliente = cliente;
            _desarrolladores = desarrolladores;
        }

        [IgnoreMember]
        public int Id { get; private set; }

        public string NombreEquipo { get; private set; }

        public string Ubicacion { get; private set; }

        public string Cliente { get; private set; }
        
        public ICollection<DtoDesarrollador> Desarrolladores { get { return _desarrolladores; } }             

       
    }
}
