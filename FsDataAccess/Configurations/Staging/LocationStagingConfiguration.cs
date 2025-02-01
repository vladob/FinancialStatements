using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class LocationStagingConfiguration : IEntityTypeConfiguration<LocationStaging>
    {
        public LocationStagingConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<LocationStaging> entity)
        {
            entity.HasKey(e => e.Code).HasName($"PK_LocationsStaging");

            entity.ToTable("Locations", "staging");

            entity.Property(e => e.Code).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        }
    }
}
