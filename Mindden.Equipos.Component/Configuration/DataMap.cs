using AutoMapper;
using Mindden.Equipos.Core.Entities.EquipoAggregate;
using Mindden.Equipos.Application.DataService;


namespace Mindden.Equipos.Configuration
{

    public static class DataMap
{

        public static void Register()
        {
                
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Equipo, DtoBasicEquipo>();
                cfg.CreateMap<DesarrolladorEquipo, DtoDesarrollador>();                
            });
               
        }

        public static void Reset()
        {
            Mapper.Reset();
        }

}


    
}
