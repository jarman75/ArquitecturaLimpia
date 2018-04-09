using Mindden.Equipos.Application.Interfaces;
using Mindden.Equipos.Application.Services;
using Mindden.Equipos.Core.Interfaces;
using Mindden.Equipos.Infrastructure.Data;

namespace Mindden.Equipos.Configuration
{
    public class EquiposRegister : StructureMap.Registry    {
        

        public EquiposRegister ()
        {
                        
            IEquipoRepository repository = EquiposEFContext.GetRepository("Data Source = localhost; Initial Catalog = ZeusTeam; Integrated Security = True");                                

            For<IEquipoService>().Use<EquipoService>().Ctor<IEquipoRepository>().Is(repository);
            
        }

        
    }
}