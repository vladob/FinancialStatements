using Microsoft.UI.Xaml;
using FsApiAccess;
using Microsoft.Extensions.Hosting;

namespace FsDesktopApp
{
    public partial class App : Application
    {
        public IHost Host { get; }

        public App()
        {
            this.InitializeComponent();
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    const string connectionString = "Server=.;Database=FinancialStatements;Trusted_Connection=False;User ID=vb;Password=vb;Encrypt=False;";
                    // var connectionString = context.Configuration.GetConnectionString("FinancialStatementsDb");
                    services.AddApiAccessServices(connectionString);
                })
                .Build();
        }

        protected override void OnLaunched(LaunchActivatedEventArgs args)
        {
            var window = new MainWindow();
            window.Activate();
        }
    }
}

