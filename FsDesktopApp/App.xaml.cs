using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace FsDesktopApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static IServiceProvider ServiceProvider { get; private set; }

    protected override void OnStartup(StartupEventArgs e)
    {
        var startup = new Startup();
        var services = new ServiceCollection();
        startup.ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();

        base.OnStartup(e);
    }
}

