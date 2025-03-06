using FsApiAccess.Models;
using FsDataAccess.Models;
using FsDataAccess.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace FsApiAccess.Services
{
    public class ApiServiceEntities
    {
        private readonly HttpClient _httpClient;
        private readonly DboContext _dboContext;
        private readonly ILogger<ApiServiceClassifications> _logger;

        public ApiServiceEntities(HttpClient httpClient, DboContext classificationsContext, ILogger<ApiServiceClassifications> logger)
        {
            _httpClient = httpClient;
            _dboContext = classificationsContext;
            _logger = logger;
        }

        public enum SearchBy
        {
            Cin,
            TaxId,
            LegalForm
        }

        public async Task<List<int>> RetrieveAndStoreEntityIdAsync(SearchBy searchBy, string searchValue)
        {
            return await RetrieveAndStoreEntityIdAsync(searchBy, searchValue, "2000-01-01");
        }
        public async Task<List<int>> RetrieveAndStoreEntityIdAsync(SearchBy searchBy, string searchValue, string changesFrom)
        {
            string apiUrl = "";
            var ids = new List<int>();
            switch (searchBy)
            {
                case SearchBy.Cin:
                    apiUrl = $"https://www.registeruz.sk/cruz-public/api/uctovne-jednotky?zmenene-od={changesFrom}&ico={searchValue}";
                    break;
                case SearchBy.TaxId:
                    apiUrl = $"https://www.registeruz.sk/cruz-public/api/uctovne-jednotky?zmenene-od={changesFrom}&dic={searchValue}";
                    break;
                case SearchBy.LegalForm:
                    apiUrl = $"https://www.registeruz.sk/cruz-public/api/uctovne-jednotky?zmenene-od={changesFrom}&pravna-forma={searchValue}";
                    break;
            }

            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiAccountingEntitieIdsResponseModel>(apiUrl);
                ids = new List<int>();
                if (responseData?.id != null)
                {
                    ids.AddRange(responseData.id);
                }
                int count = 0; // temporarely, for breakepoint
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving and storing legal forms.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
            return ids;
        }

        public async Task<ApiAccountingEntityResponseModel?> RetrieveAccountingEntityDetailsAsync(int entityId)
        {
            var apiUrl = $"https://www.registeruz.sk/cruz-public/api/uctovna-jednotka?id={entityId}";

            try
            {
                var responseData = await _httpClient.GetFromJsonAsync<ApiAccountingEntityResponseModel>(apiUrl);
                return responseData;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving details for accounting entity with ID {entityId}");
                return null;
            }
        }

        public async Task StoreAccountingEntityDetailsAsync(ApiAccountingEntityResponseModel entityDetails)
        {
            try
            {
                var entity = new AccountingEntityStaging
                {
                    ErpId = entityDetails.Id,
                    Cin = entityDetails.Ico,
                    Tin = entityDetails.Dic,
                    Sid = entityDetails.Sid,
                    TitleAe = entityDetails.NazovUJ,
                    City = entityDetails.Mesto,
                    Street = entityDetails.Ulica,
                    Zip = entityDetails.Psc,
                    Established = entityDetails.DatumZalozenia,
                    Cancellation = entityDetails.DatumZrusenia,
                    LegalFormId = entityDetails.PravnaForma,
                    SkNaceId = entityDetails.SkNace,
                    OrganizationSizeId = entityDetails.VelkostOrganizacie,
                    OwnershipTypeId = entityDetails.DruhVlastnictva,
                    RegionId = entityDetails.Kraj,
                    DistrictId = entityDetails.Okres,
                    RegisterredOfficeId = entityDetails.Sidlo,
                    Consolidated = entityDetails.Konsolidovana,
                    DataSource = entityDetails.ZdrojDat,
                    LastModification = entityDetails.DatumPoslednejUpravy
                };

                if (entityDetails.IdUctovnychZavierok != null)
                {
                    foreach (int item in entityDetails.IdUctovnychZavierok)
                    {
                        var listEntity = new FinancialStatementStaging { ErpId = item, AccountingEntityId = entityDetails.Id };
                        _dboContext.StagingFinancialStatements.Add(listEntity);
                    }
                }

                if (entityDetails.IdVyrocnychSprav != null)
                {
                    foreach (int item in entityDetails.IdVyrocnychSprav)
                    {
                        var listEntity = new AnnualReportStaging { ErpId = item, AccountingEntityId = entityDetails.Id };
                        _dboContext.StagingAnnualReports.Add(listEntity);
                    }
                }

                _dboContext.Add(entity);
                await _dboContext.SaveChangesAsync();

                // Call the upsert task
                var upsertTask = new UpsertAccountingEntities(_dboContext);
                await upsertTask.AccountingEntitiesAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error storing entity details.");
                // Handle the error (e.g., retry, notify user, etc.)
            }
        }


    }
}
