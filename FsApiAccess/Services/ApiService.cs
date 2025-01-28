using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FsApiAccess.Models;
using FsDataAccess.Models;
using Microsoft.Extensions.Logging;

namespace FsApiAccess.Services
{
    public class ApiService
    {
        private readonly HttpClient _httpClient;
        private readonly FinancialStatementsContext _context;
        private readonly ILogger<ApiService> _logger;

        public ApiService(HttpClient httpClient, FinancialStatementsContext context, ILogger<ApiService> logger)
        {
            _httpClient = httpClient;
            _context = context;
            _logger = logger;
        }

        public async Task RetrieveAndStoreLegalFormsAsync()
        {
            var apiUrl = "https://www.registeruz.sk/cruz-public/api/pravne-formy";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiClasificationResponseModel>(apiUrl);

                if (responseData?.Klasifikacie != null)
                {
                    foreach (var item in responseData.Klasifikacie)
                    {
                        var entity = new LegalForm
                        {
                            Code = item.Kod,
                            TitleEng = item.Nazov.En,
                            TitleSk = item.Nazov.Sk
                        };
                        _context.StagingLegalForms.Add(entity);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing legal forms.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }

        public async Task RetrieveAndStoreSkNaceAsync()
        {
            var apiUrl = "https://www.registeruz.sk/cruz-public/api/sk-nace";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiClasificationResponseModel>(apiUrl);

                if (responseData?.Klasifikacie != null)
                {
                    foreach (var item in responseData.Klasifikacie)
                    {
                        var entity = new SkNace
                        {
                            Code = item.Kod,
                            TitleEng = item.Nazov.En,
                            TitleSk = item.Nazov.Sk
                        };
                        _context.StagingSkNaces.Add(entity);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing SkNace.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }

        public async Task RetrieveAndStoreOwnershipTypesAsync()
        {
            var apiUrl = "https://www.registeruz.sk/cruz-public/api/druhy-vlastnictva";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiClasificationResponseModel>(apiUrl);

                if (responseData?.Klasifikacie != null)
                {
                    foreach (var item in responseData.Klasifikacie)
                    {
                        var entity = new OwnershipType
                        {
                            //ErpId = item.Kod,
                            Code = item.Kod,
                            TitleEng = item.Nazov.En,
                            TitleSk = item.Nazov.Sk
                        };
                        _context.StagingOwnershipTypes.Add(entity);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing ownership types.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }

        public async Task RetrieveAndStoreOrganizationSizesAsync()
        {
            var apiUrl = "https://www.registeruz.sk/cruz-public/api/velkosti-organizacie";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiClasificationResponseModel>(apiUrl);

                if (responseData?.Klasifikacie != null)
                {
                    foreach (var item in responseData.Klasifikacie)
                    {
                        var entity = new OrganizationSize
                        {
                            Code = item.Kod,
                            TitleEng = item.Nazov.En,
                            TitleSk = item.Nazov.Sk
                        };
                        _context.StagingOrganizationSizes.Add(entity);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing organization sizes.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }

        public async Task RetrieveAndStoreLocationsAsync()
        {
            await RetrieveAndStoreRegionsAsync();
            await RetrieveAndStoreMunicipalitiesAsync();
            await RetrieveAndStoreDistrictsAsync();
        }

        private async Task RetrieveAndStoreRegionsAsync()
        {
            var apiUrl = "https://www.registeruz.sk/cruz-public/api/kraje";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiClasificationResponseModel>(apiUrl);

                if (responseData?.Klasifikacie != null)
                {
                    foreach (var item in responseData.Klasifikacie)
                    {
                        var entity = new Location
                        {
                            Code = item.Kod,
                            TitleSk = item.Nazov.Sk,
                            ParentLocation = null
                        };
                        _context.StagingLocations.Add(entity);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing regions.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }

        private async Task RetrieveAndStoreMunicipalitiesAsync()
        {
            var apiUrl = "https://www.registeruz.sk/cruz-public/api/okresy";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiClasificationResponseModel>(apiUrl);

                if (responseData?.Klasifikacie != null)
                {
                    foreach (var item in responseData.Klasifikacie)
                    {
                        var entity = new Location
                        {
                            Code = item.Kod,
                            TitleSk = item.Nazov.Sk,
                            ParentLocation = item.NadriadenaKlasifikacia
                        };
                        _context.StagingLocations.Add(entity);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing municipalities.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }

        private async Task RetrieveAndStoreDistrictsAsync()
        {
            var apiUrl = "https://www.registeruz.sk/cruz-public/api/sidla";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiClasificationResponseModel>(apiUrl);

                if (responseData?.Klasifikacie != null)
                {
                    foreach (var item in responseData.Klasifikacie)
                    {
                        var entity = new Location
                        {
                            Code = item.Kod,
                            TitleSk = item.Nazov.Sk,
                            ParentLocation = item.NadriadenaKlasifikacia
                        };
                        _context.StagingLocations.Add(entity);
                    }
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing districts.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }
    }
}
