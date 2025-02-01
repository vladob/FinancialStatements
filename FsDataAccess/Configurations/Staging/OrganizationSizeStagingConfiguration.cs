using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class OrganizationSizeStagingConfiguration : IEntityTypeConfiguration<OrganizationSizeStaging>
    {
        public OrganizationSizeStagingConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<OrganizationSizeStaging> entity)
        {
            entity.HasKey(e => e.Code).HasName($"PK_OrganizationSizesStaging");

            entity.ToTable("OrganizationSizes", "staging");

            entity.Property(e => e.Code).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        }
    }
}
