using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class AnnualReportStagingConfiguration : IEntityTypeConfiguration<AnnualReportStaging>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public AnnualReportStagingConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<AnnualReportStaging> entity)
        {
            entity.ToTable("AnnualReports", "staging");

            entity.HasKey(e => e.ErpId).HasName("PK_staging_AnnualReports");

            entity.Property(e => e.ErpId).HasColumnName("ErpId");
            entity.Property(e => e.AccountingEntityId).HasColumnName("accountingEntityId");
            entity.Property(e => e.TitleAe).HasMaxLength(500).IsUnicode(false).HasColumnName("titleAE");
            entity.Property(e => e.Type).HasMaxLength(100).IsUnicode(false).HasColumnName("type");
            entity.Property(e => e.FundName).HasMaxLength(500).IsUnicode(false).HasColumnName("fundName");
            entity.Property(e => e.LeiCode).HasMaxLength(20).IsUnicode(false).HasColumnName("leiCode");
            entity.Property(e => e.PeriodFrom).HasMaxLength(7).IsUnicode(false).HasColumnName("periodFrom");
            entity.Property(e => e.PeriodTo).HasMaxLength(7).IsUnicode(false).HasColumnName("periodTo");
            entity.Property(e => e.SubmissionDate).HasColumnName("submissionDate");
            entity.Property(e => e.AssemblyDate).HasColumnName("assemblyDate");
            entity.Property(e => e.DataAvailability).IsUnicode(false).HasColumnName("dataAvailability");
            entity.Property(e => e.AccountingEntityId).HasColumnName("accountingEntityId");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.DataSource).HasMaxLength(30).IsUnicode(false).HasColumnName("dataSource");

            entity.HasOne<AccountingEntityStaging>() // Assuming you have this navigation property in AnnualReportStaging
                .WithMany()
                .HasForeignKey(ar => ar.AccountingEntityId);
        }
    }
}
