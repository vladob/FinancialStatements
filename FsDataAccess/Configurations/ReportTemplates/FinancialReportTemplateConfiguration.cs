using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class FinancialReportTemplateConfiguration : IEntityTypeConfiguration<FinancialReportTemplate>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public FinancialReportTemplateConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<FinancialReportTemplate> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_FinancialReportTemplates");

            entity.ToTable("FinancialReportTemplates", _schema);

            entity.Property(e => e.ErpId).HasMaxLength(30).IsUnicode(false).HasColumnName("ErpId");
            entity.Property(e => e.DataSource).HasMaxLength(30).IsUnicode(false).HasColumnName("dataSource");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.MfSpecification).HasMaxLength(100).IsUnicode(false).HasColumnName("mfSpecification");
            entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).HasColumnName("name");
            entity.Property(e => e.ValidFrom).HasColumnName("validFrom");
            entity.Property(e => e.ValidTo).HasColumnName("validTo");
        }
    }
}
