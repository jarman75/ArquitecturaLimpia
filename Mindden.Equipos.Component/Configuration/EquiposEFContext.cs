using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Mindden.Equipos.Infrastructure.Data;

namespace Mindden.Equipos.Configuration
{
    public static class EquiposEFContext
    {
        public static void ConfigureServices()
        {

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<EquiposContext>();
            builder.UseSqlServer("Data Source = localhost; Initial Catalog = ZeusTeam; Integrated Security = True")
                   .UseInternalServiceProvider(serviceProvider);

            
        }

    }
}
