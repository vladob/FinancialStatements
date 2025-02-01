using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class LegalFormStagingConfiguration : IEntityTypeConfiguration<LegalFormStaging>
    {
        public void Configure(EntityTypeBuilder<LegalFormStaging> entity)
        {
            entity.HasKey(e => e.Code).HasName($"PK_LegalFormsStaging");

            entity.ToTable("LegalForms", "staging");

            entity.Property(e => e.Code).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        }
    }
}
