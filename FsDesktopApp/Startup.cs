using FsApiAccess.Services;
using FsDataAccess;
using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FsDesktopApp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddHttpClient();
            services.AddDbContext<DboContext>(options =>
                options.UseSqlServer("Server=.;Database=FinancialStatements;Trusted_Connection=False;User ID=vb;Password=vb;Encrypt=False;"));
            services.AddTransient<ApiServiceClassifications>();
            services.AddTransient<ApiServiceEntities>();
            services.AddTransient<CinListRepository>();
            // ... register other services
        }
    }
}
