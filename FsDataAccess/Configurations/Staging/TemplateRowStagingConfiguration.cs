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
            entity.HasKey(e => e.Id).HasName("PK_TemplateRowsStaging");

            entity.ToTable("TemplateRows", "staging");

            entity.Property(e => e.RowNumber).HasColumnName("rowNumber");
            entity.Property(e => e.TextSk).IsUnicode(false).HasColumnName("textSk");
            entity.Property(e => e.TextEn).IsUnicode(false).HasColumnName("textEn");
            entity.Property(e => e.Designation).IsUnicode(false).HasColumnName("designation");

        }
    }
}
