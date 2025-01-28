using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public LocationConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<Location> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_classifications_Locations");

            entity
                .ToTable("Locations", "Classifications")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("LocationsHistory", "Classifications");
                        ttb
                            .HasPeriodStart("SysStartTime")
                            .HasColumnName("SysStartTime");
                        ttb
                            .HasPeriodEnd("SysEndTime")
                            .HasColumnName("SysEndTime");
                    }));

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ParentLocation)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        }
    }
}
