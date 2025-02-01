using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FsApiAccess.Models;
using FsDataAccess.Models;
using FsDataAccess.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FsApiAccess.Services
{
    public class ApiServiceClassifications
    {
        private readonly HttpClient _httpClient;
        private readonly ClassificationsDbContext _context;
        private readonly ILogger<ApiServiceClassifications> _logger;

        public ApiServiceClassifications(HttpClient httpClient, ClassificationsDbContext context, ILogger<ApiServiceClassifications> logger)
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
                        var entity = new LegalFormStaging
                        {
                            Code = item.Kod,
                            TitleEng = item.Nazov.En,
                            TitleSk = item.Nazov.Sk
                        };
                        _context.StagingLegalForms.Add(entity);
                    }
                    await _context.SaveChangesAsync();

                    // Call the upsert task
                    var upsertTask = new UpsertLegalFormsTask(_context);
                    await upsertTask.UpsertLegalFormsAsync();
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
                        var entity = new SkNaceStaging
                        {
                            Code = item.Kod,
                            TitleEng = item.Nazov.En,
                            TitleSk = item.Nazov.Sk
                        };
                        _context.StagingSkNaces.Add(entity);
                    }
                    await _context.SaveChangesAsync();

                    // Call the upsert task
                    var upsertTask = new UpsertSkNaceTask(_context);
                    await upsertTask.UpsertSkNaceAsync();
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
                        var entity = new OwnershipTypeStaging
                        {
                            //ErpId = item.Kod,
                            Code = item.Kod,
                            TitleEng = item.Nazov.En,
                            TitleSk = item.Nazov.Sk
                        };
                        _context.StagingOwnershipTypes.Add(entity);
                    }
                    await _context.SaveChangesAsync();

                    // Call the upsert task
                    var upsertTask = new UpsertOwnershipTypesTask(_context);
                    await upsertTask.UpsertOwnershipTypesAsync();
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
                        var entity = new OrganizationSizeStaging
                        {
                            Code = item.Kod,
                            TitleEng = item.Nazov.En,
                            TitleSk = item.Nazov.Sk
                        };
                        _context.StagingOrganizationSizes.Add(entity);
                    }
                    await _context.SaveChangesAsync();

                    // Call the upsert task
                    var upsertTask = new UpsertOrganizationSizesTask(_context);
                    await upsertTask.UpsertOrganizationSizesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing organization sizes.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }

        public async Task RetrieveAndStoreLocationsAllAsync()
        {
            await RetrieveAndStoreLocationsAsync("https://www.registeruz.sk/cruz-public/api/kraje");
            await RetrieveAndStoreLocationsAsync("https://www.registeruz.sk/cruz-public/api/okresy");
            await RetrieveAndStoreLocationsAsync("https://www.registeruz.sk/cruz-public/api/sidla");
            // Call the upsert task
            var upsertTask = new UpsertLocationsTask(_context);
            await upsertTask.UpsertLocationsAsync();
        }

        public async Task RetrieveAndStoreLocationsAsync(string apiUrl)
        {
            //var apiUrl = "https://www.registeruz.sk/cruz-public/api/kraje";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiClasificationResponseModel>(apiUrl);

                if (responseData?.Lokacie != null)
                {
                    foreach (var item in responseData.Lokacie)
                    {
                        var entity = new LocationStaging
                        {
                            Code = item.Kod,
                            TitleSk = item.Nazov.Sk,
                            TitleEng = item.Nazov.En,
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

        public async Task<ApiFinancialReportTemplateModel?> RetrieveFinancialReportTemplateAsync(int templateId)
        {
            var apiUrl = $"https://www.registeruz.sk/cruz-public/api/sablona?id={templateId}";
            try
            {
                return await _httpClient.GetFromJsonAsync<ApiFinancialReportTemplateModel>(apiUrl);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving financial report template with ID {templateId}.");
                return null;
            }
        }

        private async Task<int?> GetClassificationIdAsync(string? code, string tableName)
        {
            if (string.IsNullOrEmpty(code)) return null;

            var query = $"SELECT Id FROM [classifications].[{tableName}] WHERE Code = @code";
            var parameter = new SqlParameter("@code", code);

            return await _context.Database.ExecuteSqlRawAsync(query, parameter);
        }
    }
}
