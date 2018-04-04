using Mindden.Equipos.Core.Common;

namespace Mindden.Equipos.Application.DataService
{
    public class DtoBasicEquipo: ValueObject
    {
        public DtoBasicEquipo(int id, string NombreEquipo)
        {
            this.Id = id;
            this.NombreEquipo = NombreEquipo;
        }


        [IgnoreMember]
        public int Id { get; private set; }

        public string NombreEquipo { get; private set; }
    }
        
}
