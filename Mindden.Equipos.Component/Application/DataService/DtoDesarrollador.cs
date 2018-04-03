using Mindden.Equipos.Core.Common;

namespace Mindden.Equipos.Application.DataService
{
    public class DtoDesarrollador : ValueObject
    {

        public DtoDesarrollador(string nombre, string alias, int experiencia)
        {
            this.Nombre = nombre;
            this.Alias = alias;
            this.Experiencia = experiencia;
        }        

        public string Nombre { get; private set; }

        public string Alias { get; private set; }

        public int Experiencia { get; private set; }
    }
}
