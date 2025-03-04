﻿using FsApiAccess.Services;
using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
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
            services.AddDbContext<ClassificationsDbContext>(options =>
                options.UseSqlServer("Server=.;Database=FinancialStatements;Trusted_Connection=False;User ID=vb;Password=vb;Encrypt=False;"));
            services.AddTransient<ApiServiceClassifications>();
            // ... register other services
        }
    }
}
