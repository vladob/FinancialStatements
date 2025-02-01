using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class TemplateRowStagingConfiguration : IEntityTypeConfiguration<TemplateRowStaging>
    {
        public TemplateRowStagingConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<TemplateRowStaging> entity)
        {
            entity.ToTable("TemplateRows", "staging");

            entity.Property(e => e.RowNumber).HasColumnName("rowNumber");
            entity.Property(e => e.TextSk).IsUnicode(false).HasColumnName("text_sk");
            entity.Property(e => e.TextEn).IsUnicode(false).HasColumnName("text_en");
            entity.Property(e => e.Code).IsUnicode(false).HasColumnName("code");

        }
    }
}
