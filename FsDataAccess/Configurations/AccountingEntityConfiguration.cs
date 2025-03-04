using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class AccountingEntityConfiguration : IEntityTypeConfiguration<AccountingEntityStaging>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public AccountingEntityConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<AccountingEntityStaging> entity)
        {
            entity.ToTable("AccountingEntities", _schema);

            entity.HasKey(e => e.Id).HasName("PK_dbo_AccountingEntities");

            entity.Property(e => e.Cancellation).HasColumnName("cancellation");
            entity.Property(e => e.Cin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cin");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .HasColumnName("city");
            entity.Property(e => e.Consolidated).HasColumnName("consolidated");
            entity.Property(e => e.DataSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataSource");
            entity.Property(e => e.DistrictId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("districtId");
            entity.Property(e => e.ErpId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Established).HasColumnName("established");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.LegalFormId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("legalFormId");
            entity.Property(e => e.OrganizationSizeId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("organizationSizeId");
            entity.Property(e => e.OwnershipTypeId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ownershipTypeId");
            entity.Property(e => e.RegionId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("regionId");
            entity.Property(e => e.RegisterredOfficeId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("registerredOfficeId");
            entity.Property(e => e.Sid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sid");
            entity.Property(e => e.SkNaceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("skNaceId");
            entity.Property(e => e.Street)
                .HasMaxLength(200)
                .HasColumnName("street");
            entity.Property(e => e.Tin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tin");
            entity.Property(e => e.TitleAe)
                .HasMaxLength(500)
                .HasColumnName("titleAE");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("zip");

            entity.HasMany(d => d.AnnualReports).WithMany(p => p.AccountingEntities)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountingEntitiesAnnualReport",
                    r => r.HasOne<AnnualReport>().WithMany()
                        .HasForeignKey("AnnualReportId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accountin__Annua__5B0E7E4A"),
                    l => l.HasOne<AccountingEntityStaging>().WithMany()
                        .HasForeignKey("AccountingEntityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accountin__Accou__5A1A5A11"),
                    j =>
                    {
                        j.HasKey("AccountingEntityId", "AnnualReportId").HasName("PK__Accounti__72B514D14DD17587");
                        j.ToTable("AccountingEntities_AnnualReports", _schema);
                    });

            entity.HasMany(d => d.FinancialStatements).WithMany(p => p.AccountingEntities)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountingEntitiesFinancialStatement",
                    r => r.HasOne<FinancialStatement>().WithMany()
                        .HasForeignKey("FinancialStatementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accountin__Finan__573DED66"),
                    l => l.HasOne<AccountingEntityStaging>().WithMany()
                        .HasForeignKey("AccountingEntityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accountin__Accou__5649C92D"),
                    j =>
                    {
                        j.HasKey("AccountingEntityId", "FinancialStatementId").HasName("PK__Accounti__54B346F8C6389670");
                        j.ToTable("AccountingEntities_FinancialStatements", _schema);
                    });

            if (_useHistoryTable)
            {
                entity.ToTable("AccountingEntities_History", _schema);
            }
        }
    }
}
