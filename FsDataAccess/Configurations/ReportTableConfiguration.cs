using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class ReportTableConfiguration : IEntityTypeConfiguration<ReportTable>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public ReportTableConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<ReportTable> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_ReportTables");

            entity.Property(e => e.Data)
                .HasColumnType("money")
                .HasColumnName("data");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.FinancialReport).WithMany(p => p.ReportTables)
                .HasForeignKey(d => d.FinancialReportId)
                .HasConstraintName("FK__ReportTab__Finan__46136164");
        }
    }
}
