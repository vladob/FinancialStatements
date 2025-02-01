using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class TemplateHeaderStagingConfiguration : IEntityTypeConfiguration<TemplateHeaderStaging>
    {
        public TemplateHeaderStagingConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<TemplateHeaderStaging> entity)
        {
            entity.ToTable("TemplateHeaders", "staging");

            entity.Property(e => e.RowPosition).HasColumnName("rowPosition");
            entity.Property(e => e.ColumnPosition).HasColumnName("columnPosition");
            entity.Property(e => e.RowSpan).HasColumnName("rowSpan");
            entity.Property(e => e.ColumnSpan).HasColumnName("columnSpan");
            entity.Property(e => e.TextSk).IsUnicode(false).HasColumnName("textSk");
            entity.Property(e => e.TextEn).IsUnicode(false).HasColumnName("textEn");
        }
    }
}
