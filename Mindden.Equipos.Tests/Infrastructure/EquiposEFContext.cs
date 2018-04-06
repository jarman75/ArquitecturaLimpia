using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Mindden.Equipos.Infrastructure.Data;

namespace Mindden.Equipos.Infrastructure.Test
{
    internal static class EquiposEFContextTest
    {
        

        private static DbContextOptions<EquiposContext> CreateNewContextOptions()
        {

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkSqlServer()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<EquiposContext>();
            builder.UseSqlServer("Data Source = localhost; Initial Catalog = ZeusTeam; Integrated Security = True")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;            
        }

        private static DbContextOptions<EquiposContext> CreateNewContextInMemoryOptions(string MemoryDataBase)
        {

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<EquiposContext>();
            builder.UseInMemoryDatabase("MemoryDataBase")
                   .UseInternalServiceProvider(serviceProvider);

            return builder.Options;
        }

        public static EquipoRepository GetRepository()
        {
            EquiposContext _dbContext;                        
        
            var options = CreateNewContextOptions();

            _dbContext = new EquiposContext(options);
            return new EquipoRepository(_dbContext);
        }
        public static EquipoRepository GetRepository(string MemoryDataBase)
        {
            EquiposContext _dbContext;

            var options = CreateNewContextInMemoryOptions(MemoryDataBase);

            _dbContext = new EquiposContext(options);
            return new EquipoRepository(_dbContext);
        }
    }
}
