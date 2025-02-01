using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class OwnershipTypeStagingConfiguration : IEntityTypeConfiguration<OwnershipTypeStaging>
    {
        public OwnershipTypeStagingConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<OwnershipTypeStaging> entity)
        {
            entity.HasKey(e => e.Code).HasName($"PK_OwnershipTypesStaging");

            entity.ToTable("OwnershipTypes", "staging");

            entity.Property(e => e.Code).HasMaxLength(100).IsUnicode(false);
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        }
    }
}
