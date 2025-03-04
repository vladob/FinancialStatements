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
    public class ApiServiceTemplates
    {
        private readonly HttpClient _httpClient;
        private readonly TemplatesDbContext _context;
        private readonly ILogger<ApiServiceTemplates> _logger;

        public ApiServiceTemplates(HttpClient httpClient, TemplatesDbContext context, ILogger<ApiServiceTemplates> logger)
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

            var dbTemplate = new FinancialReportTemplateStaging
            {
                ErpId = template.id,
                Name = template.nazov,
                MfSpecification = template.nariadenieMF,
                ValidFrom = template.platneOd,
                ValidTo = template.platneDo
            };

            foreach (var table in template.tabulky)
            {
                var templateTable = new FsDataAccess.Models.TemplateTableStaging
                {
                    NameSk = table.nazov?.Sk,
                    NameEn = table.nazov?.En,
                    NumberOfDataColumns = table.pocetDatovychStlpcov,
                    NumberOfColumns = table.pocetStlpcov,
                    FinancialReportTemplate = dbTemplate
                };

                foreach (var header in table.hlavicka)
                {
                    var templateHeader = new FsDataAccess.Models.TemplateHeaderStaging
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
                    var templateRow = new FsDataAccess.Models.TemplateRowStaging
                    {
                        Designation = row.oznacenie,
                        RowNumber = row.cisloRiadku,
                        TextSk = row.text?.Sk,
                        TextEn = row.text?.En,
                        TemplateTable = templateTable
                    };
                    templateTable.TemplateRows.Add(templateRow);
                }

                dbTemplate.TemplateTables.Add(templateTable);
            }

            try
            {
                _context.StagingFinancialReportTemplate.Add(dbTemplate);
                
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
                    await SaveReportChanges();
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
                await SaveReportChanges();
            }
        }

        public async Task SaveReportChanges()
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

        public async Task StoreAccountingEntityAsync(ApiAccountingEntityResponseModel entity)
        {
            if (entity == null) return;

            var dbEntity = new AccountingEntity
            {
                ErpId = entity.Id.ToString(),
                Cin = entity.Ico,
                Tin = entity.Dic,
                Sid = entity.Sid,
                TitleAe = entity.NazovUJ,
                City = entity.Mesto,
                Street = entity.Ulica,
                Zip = entity.Psc,
                Established = entity.DatumZalozenia,
                Cancellation = entity.DatumZrusenia,
                LegalFormId = await GetClassificationIdAsync(entity.PravnaForma, "LegalForms"),
                SkNaceId = await GetClassificationIdAsync(entity.SkNace, "SkNace"),
                OrganizationSizeId = await GetClassificationIdAsync(entity.VelkostOrganizacie, "OrganizationSizes"),
                OwnershipTypeId = await GetClassificationIdAsync(entity.DruhVlastnictva, "OwnershipTypes"),
                RegionId = await GetClassificationIdAsync(entity.Kraj, "Locations"),
                DistrictId = await GetClassificationIdAsync(entity.Okres, "Locations"),
                RegisterredOfficeId = await GetClassificationIdAsync(entity.Sidlo, "Locations"),
                Consolidated = entity.Konsolidovana,
                DataSource = entity.ZdrojDat,
                LastModification = entity.DatumPoslednejUpravy
            };
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
