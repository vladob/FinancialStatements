using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FsApiAccess.Services;
using FsDataAccess.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FsDesktopApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ApiServiceClassifications _apiServiceClassifications;
    //private readonly ApiServiceTemplates _apiServiceTemplates;
    public MainWindow()
    {
        InitializeComponent();
        _apiServiceClassifications = App.ServiceProvider.GetRequiredService<ApiServiceClassifications>();
    }

    private async void btnRetrieveClassifications_Click(object sender, RoutedEventArgs e)
    {
        await RetrieveAndStoreClassificationsAsync();
    }

    private void btnRetrieveTemplates_Click(object sender, RoutedEventArgs e)
    {

    }

    private async void btnRetrieveEntity_Click(object sender, RoutedEventArgs e)
    {
        var ids = await _apiServiceClassifications.RetrieveAndStoreEntityIdAsync(ApiServiceClassifications.SearchBy.Cin, EntityCin.Text);
        //        await _apiServiceClassifications.RetrieveAndStoreEntityIdAsync(ApiServiceClassifications.SearchBy.Cin, EntityCin.Text);
        foreach (var id in ids)
        {
            AccountingEntityId.Content = id.ToString();
            Console.WriteLine(id);
        }
    }

    private async Task RetrieveAndStoreClassificationsAsync()
    {
        await _apiServiceClassifications.RetrieveAndStoreLegalFormsAsync();
        await _apiServiceClassifications.RetrieveAndStoreOrganizationSizesAsync();
        await _apiServiceClassifications.RetrieveAndStoreOwnershipTypesAsync();
        await _apiServiceClassifications.RetrieveAndStoreSkNaceAsync();
        await _apiServiceClassifications.RetrieveAndStoreLocationsAllAsync();
    }

}