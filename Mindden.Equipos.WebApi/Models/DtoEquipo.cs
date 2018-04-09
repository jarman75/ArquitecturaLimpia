using Mindden.Equipos.Application.DataService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mindden.Equipos.WebApi.Models
{
    public class DtoEquipo
    {
                
        public int Id { get; set; }

        public string NombreEquipo { get; set; }

        public string Ubicacion { get; set; }

        public string Cliente { get; set; }

        public ICollection<DtoDesarrollador> Desarrolladores { get; set; }

        public DSEquipo ToItem()
        {

            ICollection<Application.DataService.DtoDesarrollador> lista = new List<Application.DataService.DtoDesarrollador>();

            foreach (DtoDesarrollador d in Desarrolladores)
            {
                lista.Add(new Application.DataService.DtoDesarrollador(d.Nombre, d.Alias, d.Experiencia));
                
            }

            return new DSEquipo(this.NombreEquipo,this.Ubicacion, this.Cliente,lista, this.Id);
        }
        public static DtoEquipo FromItem(DSEquipo item)
        {

            ICollection<DtoDesarrollador> lista = new List<DtoDesarrollador>();
            foreach (Application.DataService.DtoDesarrollador d in item.Desarrolladores)
            {
                                
                lista.Add(new DtoDesarrollador
                {
                    Nombre = d.Nombre,
                    Alias = d.Alias,
                    Experiencia = d.Experiencia
                });
            }

            return new DtoEquipo()
            {
                Id = item.Id,
                NombreEquipo = item.NombreEquipo,
                Ubicacion = item.Ubicacion,
                Cliente = item.Cliente,
                Desarrolladores = lista
            };             
            
        }
    }
}
