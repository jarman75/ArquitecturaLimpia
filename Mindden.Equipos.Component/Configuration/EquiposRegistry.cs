using StructureMap;
using Mindden.Equipos.Application.Interfaces;
using Mindden.Equipos.Application.Services;
using Mindden.Equipos.Core.Interfaces;
using Mindden.Equipos.Infrastructure.Data;


namespace Mindden.Equipos.Configuration
{
    public class EquiposRegistry : Registry
    {
        public EquiposRegistry()
        {


            For<IEquipoRepository>().Use<EquipoRepository>();
            this.Policies.SetAllProperties(p => p.WithAnyTypeFromNamespaceContainingType<EquipoRepository>());

            For<IEquipoService>().Use<EquipoService>().Ctor<IEquipoRepository>();            
            this.Policies.SetAllProperties(p=> p.WithAnyTypeFromNamespaceContainingType<EquipoService>());
            
        }
    }
}