using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Mindden.Equipos.Infrastructure.Data;

namespace Mindden.Equipos.Configuration
{
    internal static class EquiposEFContext
    {            
                
        public static EquipoRepository GetRepository(string connectionString)
        {
            EquiposContext _dbContext;

            var options = CreateNewContextOptions(connectionString);

            _dbContext = new EquiposContext(options);
            return new EquipoRepository(_dbContext);
        }

        private static DbContextOptions<EquiposContext> CreateNewContextOptions(string connectionString)
        {

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<EquiposContext>();
            builder.UseSqlServer(connectionString)
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

    }
}
