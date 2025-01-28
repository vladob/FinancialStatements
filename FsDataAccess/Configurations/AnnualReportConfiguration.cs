using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class AnnualReportConfiguration : IEntityTypeConfiguration<AnnualReport>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public AnnualReportConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<AnnualReport> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_AnnualReports");

            entity.Property(e => e.AccountingEntityId).HasColumnName("accountingEntityId");
            entity.Property(e => e.AssemblyDate).HasColumnName("assemblyDate");
            entity.Property(e => e.DataAvailability)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataAvailability");
            entity.Property(e => e.DataSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataSource");
            entity.Property(e => e.FundName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fundName");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
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
            entity.Property(e => e.SubmissionDate).HasColumnName("submissionDate");
            entity.Property(e => e.TitleAe)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("titleAE");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type");
        }
    }
}
