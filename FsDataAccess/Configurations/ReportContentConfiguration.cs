using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class ReportContentConfiguration : IEntityTypeConfiguration<ReportContent>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public ReportContentConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<ReportContent> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_ReportContents");

            entity.Property(e => e.ApprovalDate).HasColumnName("approvalDate");
            entity.Property(e => e.AssemblyDate).HasColumnName("assemblyDate");
            entity.Property(e => e.AuditorReportAttachmentDate).HasColumnName("auditorReportAttachmentDate");
            entity.Property(e => e.CommercialRegister)
                .IsUnicode(false)
                .HasColumnName("commercialRegister");
            entity.Property(e => e.CompletionDate).HasColumnName("completionDate");
            entity.Property(e => e.CoverPageAddress)
                .IsUnicode(false)
                .HasColumnName("coverPageAddress");
            entity.Property(e => e.CoverPageConsolidated).HasColumnName("coverPageConsolidated");
            entity.Property(e => e.CoverPageConsolidatedCg).HasColumnName("coverPageConsolidatedCG");
            entity.Property(e => e.CoverPageDic)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("coverPageDic");
            entity.Property(e => e.CoverPageIco)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("coverPageIco");
            entity.Property(e => e.CoverPageLegalFormId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("coverPageLegalFormId");
            entity.Property(e => e.CoverPageSid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("coverPageSid");
            entity.Property(e => e.CoverPageSkNaceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("coverPageSkNaceId");
            entity.Property(e => e.CoverPageSummaryPa).HasColumnName("coverPageSummaryPA");
            entity.Property(e => e.CoverPageTitle)
                .IsUnicode(false)
                .HasColumnName("coverPageTitle");
            entity.Property(e => e.CoverPageType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("coverPageType");
            entity.Property(e => e.CoverPageTypeUnit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("coverPageTypeUnit");
            entity.Property(e => e.FundName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fundName");
            entity.Property(e => e.LeiCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("leiCode");
            entity.Property(e => e.PeriodFrom)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("periodFrom");
            entity.Property(e => e.PeriodTo)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("periodTo");
            entity.Property(e => e.PreparationDate).HasColumnName("preparationDate");
            entity.Property(e => e.PreviousPeriodFrom)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("previousPeriodFrom");
            entity.Property(e => e.PreviousPeriodTo)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("previousPeriodTo");

            entity.HasOne(d => d.FinancialReport).WithMany(p => p.ReportContents)
                .HasForeignKey(d => d.FinancialReportId)
                .HasConstraintName("FK__ReportCon__Finan__4336F4B9");
        }
    }
}
