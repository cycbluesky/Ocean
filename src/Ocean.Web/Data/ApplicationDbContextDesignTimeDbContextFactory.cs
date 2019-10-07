using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Ocean.Web.Data
{
    public class ApplicationDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        ApplicationDbContext IDesignTimeDbContextFactory<ApplicationDbContext>.CreateDbContext(string[] args)
        {
            Console.WriteLine($"Call {nameof(ApplicationDbContextDesignTimeDbContextFactory)} on {DateTime.Now}");

            var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.Development.json")
               .Build();
            var connectionString = configuration.GetConnectionString("Ocean");
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseNpgsql(connectionString,
                   p =>
                   {
                       p.MigrationsAssembly("Ocean.Web");
                       p.CommandTimeout(20);
                   });

            Console.WriteLine($"ConnectionString: {connectionString}");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
