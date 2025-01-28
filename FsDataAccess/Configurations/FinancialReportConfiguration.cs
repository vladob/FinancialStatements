using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class FinancialReportConfiguration : IEntityTypeConfiguration<FinancialReport>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public FinancialReportConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<FinancialReport> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_FinancialReports");

            entity.Property(e => e.Currency)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.DataAvailability)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataAvailability");
            entity.Property(e => e.DataSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataSource");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.TaxOfficeCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("taxOfficeCode");

            entity.HasOne(d => d.AnnualReport).WithMany(p => p.FinancialReports)
                .HasForeignKey(d => d.AnnualReportId)
                .HasConstraintName("FK__Financial__Annua__3D7E1B63");

            entity.HasOne(d => d.FinancialStatement).WithMany(p => p.FinancialReports)
                .HasForeignKey(d => d.FinancialStatementId)
                .HasConstraintName("FK__Financial__Finan__3C89F72A");
        }
    }
}
