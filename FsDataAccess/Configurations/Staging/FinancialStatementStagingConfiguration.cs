using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class FinancialStatementStagingConfiguration : IEntityTypeConfiguration<FinancialStatementStaging>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public FinancialStatementStagingConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<FinancialStatementStaging> entity)
        {
            entity.ToTable("FinancialStatements", "staging");

            entity.HasKey(e => e.ErpId).HasName("PK_staging_FinancialStatements");

            entity.Property(e => e.ErpId).HasColumnName("ErpId");
            entity.Property(e => e.AccountingEntityId).HasColumnName("accountingEntityId");
            entity.Property(e => e.PeriodFrom).HasMaxLength(7).IsUnicode(false).HasColumnName("periodFrom");
            entity.Property(e => e.PeriodTo).HasMaxLength(7).IsUnicode(false).HasColumnName("periodTo");
            entity.Property(e => e.SubmissionDate).HasColumnName("submissionDate");
            entity.Property(e => e.PreparationDate).HasColumnName("preparationDate");
            entity.Property(e => e.ApprovalDate).HasColumnName("approvalDate");
            entity.Property(e => e.AssemblyDate).HasColumnName("assemblyDate");
            entity.Property(e => e.AuditorReportAttachmentDate).HasColumnName("auditorReportAttachmentDate");
            entity.Property(e => e.FundName).HasMaxLength(500).IsUnicode(false).HasColumnName("fundName");
            entity.Property(e => e.LeiCode).HasMaxLength(20).IsUnicode(false).HasColumnName("leiCode");
            entity.Property(e => e.Consolidated).HasColumnName("consolidated");
            entity.Property(e => e.ConsolidatedCentralGovernment).HasColumnName("consolidatedCentralGovernment");
            entity.Property(e => e.SummaryPublicAdministration).HasColumnName("summaryPublicAdministration");
            entity.Property(e => e.Type).HasMaxLength(50).IsUnicode(false).HasColumnName("type");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.DataSource).HasMaxLength(30).IsUnicode(false).HasColumnName("dataSource");

        }
    }
}
