using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class AccountingEntityStagingConfiguration : IEntityTypeConfiguration<AccountingEntityStaging>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public AccountingEntityStagingConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<AccountingEntityStaging> entity)
        {
            entity.ToTable("AccountingEntities", "staging");

            entity.HasKey(e => e.ErpId).HasName("[PK_staging_AccountingEntities]");

            entity.Property(e => e.ErpId).HasMaxLength(10).IsUnicode(false);
            entity.Property(e => e.Cin).HasMaxLength(20).IsUnicode(false).HasColumnName("cin");
            entity.Property(e => e.Tin).HasMaxLength(20).IsUnicode(false).HasColumnName("tin");
            entity.Property(e => e.Sid).HasMaxLength(20).IsUnicode(false).HasColumnName("sid");
            entity.Property(e => e.TitleAe).HasMaxLength(500).HasColumnName("titleAE");
            entity.Property(e => e.City).HasMaxLength(200).HasColumnName("city");
            entity.Property(e => e.Street).HasMaxLength(200).HasColumnName("street");
            entity.Property(e => e.Zip).HasMaxLength(10).IsUnicode(false).HasColumnName("zip");
            entity.Property(e => e.Established).HasColumnName("established");
            entity.Property(e => e.Cancellation).HasColumnName("cancellation");
            entity.Property(e => e.LegalFormId).HasMaxLength(100).IsUnicode(false).HasColumnName("legalFormId");
            entity.Property(e => e.SkNaceId).HasMaxLength(100).IsUnicode(false).HasColumnName("skNaceId");
            entity.Property(e => e.OrganizationSizeId).HasMaxLength(100).IsUnicode(false).HasColumnName("organizationSizeId");
            entity.Property(e => e.OwnershipTypeId).HasMaxLength(100).IsUnicode(false).HasColumnName("ownershipTypeId");
            entity.Property(e => e.RegionId).HasMaxLength(100).IsUnicode(false).HasColumnName("regionId");
            entity.Property(e => e.DistrictId).HasMaxLength(100).IsUnicode(false).HasColumnName("districtId");
            entity.Property(e => e.RegisterredOfficeId).HasMaxLength(100).IsUnicode(false).HasColumnName("registerredOfficeId");
            entity.Property(e => e.Consolidated).HasColumnName("consolidated");
            entity.Property(e => e.DataSource).HasMaxLength(30).IsUnicode(false).HasColumnName("dataSource");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");

            // Configure relationship with Annual Reports
            entity.HasMany(e => e.AnnualReports).WithOne().HasForeignKey(ear => ear.AccountingEntityId).HasPrincipalKey(e => e.ErpId); // Add this line

            // Configure relationship with Financial Statements
            entity.HasMany(e => e.FinancialStatements).WithOne().HasForeignKey(efs => efs.AccountingEntityId).HasPrincipalKey(e => e.ErpId); // Add this line
        }
    }
}
