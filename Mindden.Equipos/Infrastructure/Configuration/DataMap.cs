using AutoMapper;
using Mindden.Equipos.Core.Entities;
using Mindden.Equipos.Core.Entities.EquipoAggregate;
using Mindden.Equipos.Services.DataService;

namespace Mindden.Equipos.Infrastructure.Configuration
{

    public static class DataMap
{

        public static void Register()
        {
                
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<BaseEquipo, DtoBasicEquipo>();
                cfg.CreateMap<DesarrolladorEquipo, DtoDesarrollador>();                
            });
               
        }

        public static void Reset()
        {
            Mapper.Reset();
        }

}


    
}
