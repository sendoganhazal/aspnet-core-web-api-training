using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Repositories.EFCore;

namespace WebApi.ContextFactory
{
    public class RepositoryContextFactory 
        : IDesignTimeDbContextFactory<RepositoryContext>
    {
        public RepositoryContext CreateDbContext ( string[] args )
        {
            // Configuration
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            // Db Context Options Builder
            
            var builder = new DbContextOptionsBuilder<RepositoryContext>()
                .UseSqlite(configuration.GetConnectionString("sqlConnection"),
                prj => prj.MigrationsAssembly("WebApi"));

            return new RepositoryContext(builder.Options);
        }
    }
}
