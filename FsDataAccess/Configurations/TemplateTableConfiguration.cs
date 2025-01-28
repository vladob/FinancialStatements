using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class TemplateTableConfiguration : IEntityTypeConfiguration<TemplateTable>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public TemplateTableConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<TemplateTable> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_TemplateTables");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.FinancialReportTemplate).WithMany(p => p.TemplateTables)
                .HasForeignKey(d => d.FinancialReportTemplateId)
                .HasConstraintName("FK__TemplateT__Finan__4DB4832C");
        }
    }
}
