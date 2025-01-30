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

        public async Task StoreFinancialReportTemplateAsync(ApiFinancialReportTemplateModel template)
        {
            if (template == null) return;

            var dbTemplate = new FinancialReportTemplate
            {
                ErpId = template.id,
                Name = template.nazov,
                MfSpecification = template.nariadenieMF,
                ValidFrom = template.platneOd,
                ValidTo = template.platneDo
            };

            foreach (var table in template.tabulky)
            {
                var templateTable = new FsDataAccess.Models.TemplateTable
                {
                    NameSk = table.nazov?.Sk,
                    NameEn = table.nazov?.En,
                    NumberOfDataColumns = table.pocetDatovychStlpcov,
                    NumberOfColumns = table.pocetStlpcov,
                    FinancialReportTemplate = dbTemplate
                };

                foreach (var header in table.hlavicka)
                {
                    var templateHeader = new FsDataAccess.Models.TemplateHeader
                    {
                        TextSk = header.text?.Sk,
                        TextEn = header.text?.En,
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
                        DescriptionSk = row.text?.Sk,
                        DescriptionEn = row.text?.En,
                        TemplateTable = templateTable
                    };
                    templateTable.TemplateRows.Add(templateRow);
                }

                dbTemplate.TemplateTables.Add(templateTable);
            }

            try
            {
                _context.StagingFinancialReportTemplates.Add(dbTemplate);
//                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving financial report template to the database.");
                throw; // Re-throw the exception to handle it further up the call stack if needed
            }

            // Call the upsert task
//            var upsertTask = new UpsertFinancialReportTemplatesTask(_context);
//            await upsertTask.UpsertFinancialReportTemplatesAsync();
        }

        public async Task RetrieveAllFinancialReportTemplatesAsync()
        {
            var apiUrl = "https://www.registeruz.sk/cruz-public/api/sablony";
            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiAllFinancialReportTemplatesResponseModel>(apiUrl);

                if (responseData?.sablony != null)
                {
                    foreach (var template in responseData.sablony)
                    {
                        await StoreFinancialReportTemplateAsync(template);
                    }
                    await SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing all financial report templates.");
            }         
        }

        public async Task RetrieveAndStoreFinancialReportTemplateAsync(int templateId)
        {
            var template = await RetrieveFinancialReportTemplateAsync(templateId);
            if (template != null)
            {
                await StoreFinancialReportTemplateAsync(template);
                await SaveChanges();
            }
        }

        public async Task SaveChanges()
        {
            try
            {
                  await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving financial report template to the database.");
                throw; // Re-throw the exception to handle it further up the call stack if needed
            }

            // Call the upsert task
            try
            {
                var upsertTask = new UpsertFinancialReportTemplatesTask(_context);
                await upsertTask.UpsertFinancialReportTemplatesAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving financial report template to the database.");
                throw; // Re-throw the exception to handle it further up the call stack if needed
            }
}   
    }
}
