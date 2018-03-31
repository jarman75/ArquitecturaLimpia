using Mindden.Equipos.Core.Entities.EquipoAggregate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mindden.Equipos.Services.DataService
{
    public class DSEquipo
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

        public int Id { get; set; }
        public string NombreEquipo { get; set; }
        public string Ubicacion { get; set; }
        public string Cliente { get; set; }
        
        public ICollection<DtoDesarrollador> Desarrolladores { get { return _desarrolladores; }  }             

       
    }
}
