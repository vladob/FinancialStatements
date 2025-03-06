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
using FsDataAccess;
using FsDataAccess.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SqlServer.Server;

namespace FsDesktopApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly ApiServiceClassifications _apiServiceClassifications;
    private readonly ApiServiceEntities _apiServiceEntities;
    private readonly CinListRepository _cinListRepository;

    //private readonly ApiServiceTemplates _apiServiceTemplates;
    public MainWindow()
    {
        InitializeComponent();
        _apiServiceClassifications = App.ServiceProvider.GetRequiredService<ApiServiceClassifications>();
        _apiServiceEntities = App.ServiceProvider.GetRequiredService<ApiServiceEntities>();
        _cinListRepository = App.ServiceProvider.GetRequiredService <CinListRepository>();
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
        await retrieveAndStoreEntityDetails(EntityCin.Text);
    }

    private async void btnProcessCinList_Click(object sender, RoutedEventArgs e)
    {
        await ProcessCinList();
    }

    private async Task retrieveAndStoreEntityDetails(string cin)
    {
        var ids = await _apiServiceEntities.RetrieveAndStoreEntityIdAsync(ApiServiceEntities.SearchBy.Cin, cin);
        //        await _apiServiceClassifications.RetrieveAndStoreEntityIdAsync(ApiServiceClassifications.SearchBy.Cin, EntityCin.Text);
        foreach (var id in ids)
        {
            AccountingEntityId.Content = id.ToString();
            await _apiServiceEntities.RetrieveAndStoreAccountingEntityDataAsync(id);
        }
    }

    private async Task ProcessCinList()
    {
        List<string> cins = _cinListRepository.GetUnprocessedCINs();

        foreach (string cin in cins)
        {
            try
            {
                await retrieveAndStoreEntityDetails(cin);
                _cinListRepository.UpdateCINStatus(cin, true);
            }
            catch (Exception ex)
            {
                _cinListRepository.UpdateCINStatus(cin, false, ex.Message);
                MessageBox.Show($"Error processing CIN {cin}: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        MessageBox.Show("CIN list processing completed.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    private async Task retrieveEntityDetails(int entityId)
    {
        
        var entityDetails = await _apiServiceEntities.RetrieveAccountingEntityDetailsAsync(entityId);

        if (entityDetails != null)
        {
            await _apiServiceEntities.StoreAccountingEntityDetailsAsync(entityDetails);
        }
        else
        {
            MessageBox.Show($"Failed to retrieve entity details for ID { entityId}.");
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