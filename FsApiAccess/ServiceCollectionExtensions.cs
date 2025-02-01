using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FsApiAccess.Services;
using System.Net.Http; // Add this using directive
using Microsoft.Extensions.Http;
using FsDataAccess.Models; // Add this using directive

namespace FsApiAccess
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApiAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TemplatesDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddHttpClient<ApiServiceClassifications>(); // Ensure ApiServiceClassifications is defined and accessible
            services.AddTransient<ApiServiceClassifications>();

            return services;
        }
    }
}
