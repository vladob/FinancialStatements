using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FsApiAccess.Models;
using FsDataAccess.Models;
using FsDataAccess.Tasks;
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
                        var entity = new SkNace
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
                        var entity = new OrganizationSize
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
                        var entity = new Location
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

        public async Task RetrieveAndStoreFinancialReportTemplateAsync(int templateId)
        {
            var apiUrl = $"https://www.registeruz.sk/cruz-public/api/sablona?id={templateId}";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiFinancialReportTemplateModel>(apiUrl);

                if (responseData != null)
                {
                    var template = new FsDataAccess.Models.FinancialReportTemplate
                    {
                        ErpId = responseData.id,
                        Name = responseData.nazov,
                        MfSpecification = responseData.nariadenieMF,
                        ValidFrom = responseData.platneOd,
                        ValidTo = responseData.platneDo
                    };

                    foreach (var table in responseData.tabulky)
                    {
                        var templateTable = new FsDataAccess.Models.TemplateTable
                        {
                            NameSk = table.nazov.Sk,
                            NameEn = table.nazov.En,
                            NumberOfDataColumns = table.pocetDatovychStlpcov,
                            NumberOfColumns = table.pocetStlpcov,
                            FinancialReportTemplate = template
                        };

                        foreach (var header in table.hlavicka)
                        {
                            var templateHeader = new FsDataAccess.Models.TemplateHeader
                            {
                                TextSk = header.text.Sk,
                                TextEn = header.text.En,
                                RowPosition = header.riadok,
                                ColumnSpan = header.sirkaStlpca,
                                ColumnPosition = header.stlpec,
                                RowSpan = header.vyskaRiadku,
                                TemplateTable = templateTable
                            };
                            templateTable.TemplateHeaders.Add(templateHeader);
                        }


                        foreach (var row in table.riadky)
                        {
                            var templateRow = new FsDataAccess.Models.TemplateRow
                            {
                                Code = row.oznacenie,
                                RowNumber = row.cisloRiadku,
                                DescriptionSk = row.text.Sk,
                                DescriptionEn = row.text.En,
                                TemplateTable = templateTable
                            };
                            templateTable.TemplateRows.Add(templateRow);
                        }

                        template.TemplateTables.Add(templateTable);
                    }

                    _context.StagingFinancialReportTemplates.Add(template);
                    await _context.SaveChangesAsync();

                    // Call the upsert task
                    var upsertTask = new UpsertFinancialReportTemplatesTask(_context);
                    await upsertTask.UpsertFinancialReportTemplatesAsync();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing financial report template.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }

    }
}
