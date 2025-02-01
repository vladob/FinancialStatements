using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
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
            entity.HasKey(e => e.Id).HasName($"PK_{_schema}_TemplateTables");

            entity.ToTable("TemplateTables", _schema);

            if (_useHistoryTable)
            {
                entity.ToTable(tb => tb.IsTemporal(ttb =>
                {
                    ttb.UseHistoryTable("TemplateTablesHistory", "versioning");
                    ttb.HasPeriodStart("SysStartTime").HasColumnName("SysStartTime");
                    ttb.HasPeriodEnd("SysEndTime").HasColumnName("SysEndTime");
                }));

                // Configure SysStartTime and SysEndTime as read-only
                entity.Property<DateTime>("SysStartTime").ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property<DateTime>("SysEndTime").ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }

            entity.Property(e => e.NameSk).HasMaxLength(100).IsUnicode(false).HasColumnName("nameSk");
            entity.Property(e => e.NameEn).HasMaxLength(100).IsUnicode(false).HasColumnName("nameEn");
            entity.Property(e => e.NumberOfColumns).HasMaxLength(100).IsUnicode(false).HasColumnName("NumberOfColumns");
            entity.Property(e => e.NumberOfDataColumns).HasMaxLength(100).IsUnicode(false).HasColumnName("NumberOfDataColumns");

            entity.HasOne(d => d.FinancialReportTemplate).WithMany(p => p.TemplateTables)
                .HasForeignKey(d => d.FinancialReportTemplateId)
                .HasConstraintName("FK__TemplateT__Finan__4DB4832C");
        }
    }
}
