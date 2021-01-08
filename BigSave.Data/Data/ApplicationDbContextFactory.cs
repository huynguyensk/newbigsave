using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

using System.IO;
namespace BigSave.Data.Data.Data
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                 .SetBasePath(Directory.GetCurrentDirectory())
                 .AddJsonFile("appsettings.json")
                 .Build();
            //var connectionString = configuration.GetConnectionString("DefaultConnection");
            //var connectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; Initial Catalog = BigSaveDb; Integrated Security = True; ";
            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("PostgresConnection");
            builder.UseNpgsql(connectionString);
            return new ApplicationDbContext(builder.Options);


            // var connectionString = "Host=hansken.db.elephantsql.com;Port=5432;Database=zgihsbde;Username=zgihsbde;Password=3XYlw5JzCCY1pu1WlKm3ygYZAXI_4qPn;";
            // var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            // optionsBuilder.UseSqlServer(connectionString);
            // return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}