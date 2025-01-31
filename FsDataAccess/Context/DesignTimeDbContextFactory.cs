using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.Configuration.FileExtensions; // Add this using directive
using Microsoft.Extensions.Configuration.Json; // Add this using directive
using System.IO;

namespace FsDataAccess.Models
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FinancialStatementsContext>
    {
        public FinancialStatementsContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<FinancialStatementsContext>();

            // Adjust the path to your appsettings.json file as needed
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("FinancialStatementsDb");
            optionsBuilder.UseSqlServer(connectionString);

            return new FinancialStatementsContext(optionsBuilder.Options, configuration, null);
        }
    }
}
