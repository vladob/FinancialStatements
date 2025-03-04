using Microsoft.UI.Xaml;
using FsApiAccess.Services;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace FsDesktopApp
{
    public sealed partial class MainWindow : Window
    {
        private readonly ApiServiceClassifications _apiServiceClassifications;
        private readonly ApiServiceTemplates _apiServiceTemplates;

        public MainWindow()
        {
            this.InitializeComponent();
            _apiServiceClassifications = ((App)Application.Current).Host.Services.GetRequiredService<ApiServiceClassifications>();
            _apiServiceTemplates = ((App)Application.Current).Host.Services.GetRequiredService<ApiServiceTemplates>();
        }

        private async void OnRetrieveClassificationsButtonClick(object sender, RoutedEventArgs e)
        {
            await RetrieveAndStoreClassificationsAsync();
            // Update UI to reflect data retrieval
        }

        private async void OnRetrieveTemplatesButtonClick(object sender, RoutedEventArgs e)
        {
            await RetrieveAndStoreTemplatesAsync();
            // Update UI to reflect data retrieval
        }
        private async void OnRetrieveEntityButtonClick(object sender, RoutedEventArgs e)
        {
            await RetrieveAndStoreEntityAsync();
            // Update UI to reflect data retrieval
        }

        private async Task RetrieveAndStoreClassificationsAsync()
        {
            await _apiServiceClassifications.RetrieveAndStoreLegalFormsAsync();
            await _apiServiceClassifications.RetrieveAndStoreSkNaceAsync();
            await _apiServiceClassifications.RetrieveAndStoreOwnershipTypesAsync();
            await _apiServiceClassifications.RetrieveAndStoreOrganizationSizesAsync();
            await _apiServiceClassifications.RetrieveAndStoreLocationsAllAsync();
            
            //            await _apiServiceClassifications.RetrieveAndStoreFinancialReportTemplateAsync(7);
        }

        private async Task RetrieveAndStoreTemplatesAsync()
        {
            await _apiServiceTemplates.RetrieveAllFinancialReportTemplatesAsync();
        }

        private async Task RetrieveAndStoreEntityAsync()
        {

        }
    }
}

