using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class FinancialReportTemplateStagingConfiguration : IEntityTypeConfiguration<FinancialReportTemplateStaging>
    {
        public FinancialReportTemplateStagingConfiguration()
        {
        }
        public void Configure(EntityTypeBuilder<FinancialReportTemplateStaging> entity)
        {
            entity.HasKey(e => e.ErpId).HasName("PK_FinancialReportTemplatesStaging");

            entity.ToTable("FinancialReportTemplates", "staging");

            entity.Property(e => e.ErpId).HasMaxLength(30).IsUnicode(false).HasColumnName("ErpId");
            entity.Property(e => e.Name).HasMaxLength(100).IsUnicode(false).HasColumnName("name");
            entity.Property(e => e.MfSpecification).HasMaxLength(100).IsUnicode(false).HasColumnName("mfSpecification");
            entity.Property(e => e.ValidFrom).HasColumnName("validFrom");
            entity.Property(e => e.ValidTo).HasColumnName("validTo");
        }
    }
}
