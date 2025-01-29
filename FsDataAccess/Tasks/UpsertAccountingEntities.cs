using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FsDataAccess.Models;

namespace FsDataAccess.Tasks
{
    public class UpsertAccountingEntitiesTask
    {
        private readonly FinancialStatementsContext _context;

        public UpsertAccountingEntitiesTask(FinancialStatementsContext context)
        {
            _context = context;
        }

        public async Task UpsertAccountingEntitiesAsync()
        {
            var stagingEntities = await _context.StagingAccountingEntities.ToListAsync();

            foreach (var stagingEntity in stagingEntities)
            {
                var existingEntity = await _context.AccountingEntities
                    .FirstOrDefaultAsync(e => e.Id == stagingEntity.Id);

                if (existingEntity != null)
                {
                    // Update existing entity
                    existingEntity.ErpId = stagingEntity.ErpId;
                    existingEntity.Cin = stagingEntity.Cin;
                    existingEntity.Tin = stagingEntity.Tin;
                    existingEntity.Sid = stagingEntity.Sid;
                    existingEntity.TitleAe = stagingEntity.TitleAe;
                    existingEntity.City = stagingEntity.City;
                    existingEntity.Street = stagingEntity.Street;
                    existingEntity.Zip = stagingEntity.Zip;
                    existingEntity.Established = stagingEntity.Established;
                    existingEntity.Cancellation = stagingEntity.Cancellation;
                    existingEntity.LegalFormId = stagingEntity.LegalFormId;
                    existingEntity.SkNaceId = stagingEntity.SkNaceId;
                    existingEntity.OrganizationSizeId = stagingEntity.OrganizationSizeId;
                    existingEntity.OwnershipTypeId = stagingEntity.OwnershipTypeId;
                    existingEntity.RegionId = stagingEntity.RegionId;
                    existingEntity.DistrictId = stagingEntity.DistrictId;
                    existingEntity.RegisterredOfficeId = stagingEntity.RegisterredOfficeId;
                    existingEntity.Consolidated = stagingEntity.Consolidated;
                    existingEntity.DataSource = stagingEntity.DataSource;
                    existingEntity.LastModification = stagingEntity.LastModification;
                }
                else
                {
                    // Insert new entity
                    _context.AccountingEntities.Add(new AccountingEntity
                    {
                        Id = stagingEntity.Id,
                        ErpId = stagingEntity.ErpId,
                        Cin = stagingEntity.Cin,
                        Tin = stagingEntity.Tin,
                        Sid = stagingEntity.Sid,
                        TitleAe = stagingEntity.TitleAe,
                        City = stagingEntity.City,
                        Street = stagingEntity.Street,
                        Zip = stagingEntity.Zip,
                        Established = stagingEntity.Established,
                        Cancellation = stagingEntity.Cancellation,
                        LegalFormId = stagingEntity.LegalFormId,
                        SkNaceId = stagingEntity.SkNaceId,
                        OrganizationSizeId = stagingEntity.OrganizationSizeId,
                        OwnershipTypeId = stagingEntity.OwnershipTypeId,
                        RegionId = stagingEntity.RegionId,
                        DistrictId = stagingEntity.DistrictId,
                        RegisterredOfficeId = stagingEntity.RegisterredOfficeId,
                        Consolidated = stagingEntity.Consolidated,
                        DataSource = stagingEntity.DataSource,
                        LastModification = stagingEntity.LastModification
                    });
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
