using Microsoft.UI.Xaml;
using FsApiAccess;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using FsDataAccess.Cache;
using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FsDesktopApp
{
    public partial class App : Application
    {
        public IHost Host { get; }

        public App()
        {
            this.InitializeComponent();
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    const string connectionString = "Server=.;Database=FinancialStatements;Trusted_Connection=False;User ID=vb;Password=vb;Encrypt=False;";
                    // var connectionString = context.Configuration.GetConnectionString("FinancialStatementsDb");
                    services.AddApiAccessServices(connectionString);

                    services.AddDbContext<FinancialStatementsContext>(options =>
                        options.UseSqlServer(connectionString));

                    services.AddSingleton<ClassificationCache>();

                    // Register other services and view models
                    services.AddTransient<MainWindow>();
                })
                .Build();
        }

        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            await Host.StartAsync();

            var context = Host.Services.GetRequiredService<FinancialStatementsContext>();
            await context.InitializeAsync();

            var window = Host.Services.GetRequiredService<MainWindow>();
            window.Activate();
        }
    }
}

