using Microsoft.UI.Xaml;
using FsApiAccess.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FsDesktopApp
{
    public sealed partial class MainWindow : Window
    {
        private readonly ApiService _apiService;

        public MainWindow()
        {
            this.InitializeComponent();
            _apiService = ((App)Application.Current).Host.Services.GetRequiredService<ApiService>();
        }

        private async void OnRetrieveDataButtonClick(object sender, RoutedEventArgs e)
        {
            await RetrieveAndStoreDataAsync();
            // Update UI to reflect data retrieval
        }

        private async Task RetrieveAndStoreDataAsync()
        {
/*            
            await _apiService.RetrieveAndStoreLegalFormsAsync();
            await _apiService.RetrieveAndStoreSkNaceAsync();
            await _apiService.RetrieveAndStoreOwnershipTypesAsync();
            await _apiService.RetrieveAndStoreOrganizationSizesAsync();
            await _apiService.RetrieveAndStoreLocationsAllAsync();
*/            
            await _apiService.RetrieveAndStoreFinancialReportTemplateAsync(0);
        }
    }
}

