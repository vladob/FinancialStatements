using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class TemplateTableStagingConfiguration : IEntityTypeConfiguration<TemplateTableStaging>
    {
        public TemplateTableStagingConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<TemplateTableStaging> entity)
        {
            entity.ToTable("TemplateTables", "staging");

            entity.Property(e => e.NameSk).HasMaxLength(100).IsUnicode(false).HasColumnName("nameSk");
            entity.Property(e => e.NameEn).HasMaxLength(100).IsUnicode(false).HasColumnName("nameEn");
            entity.Property(e => e.NumberOfColumns).HasMaxLength(100).IsUnicode(false).HasColumnName("NumberOfColumns");
            entity.Property(e => e.NumberOfDataColumns).HasMaxLength(100).IsUnicode(false).HasColumnName("NumberOfDataColumns");
        }
    }
}
