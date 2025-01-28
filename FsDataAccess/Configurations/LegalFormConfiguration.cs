using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class LegalFormConfiguration : IEntityTypeConfiguration<LegalForm>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public LegalFormConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<LegalForm> entity)
        {
            entity.HasKey(e => e.Id).HasName($"PK_{_schema}_LegalForms");

            entity.ToTable("LegalForms", _schema);

            if (_useHistoryTable)
            {
                entity.ToTable(tb => tb.IsTemporal(ttb =>
                {
                    ttb.UseHistoryTable("LegalFormsHistory", "versioning");
                    ttb.HasPeriodStart("SysStartTime").HasColumnName("SysStartTime");
                    ttb.HasPeriodEnd("SysEndTime").HasColumnName("SysEndTime");
                }));

                // Configure SysStartTime and SysEndTime as read-only
                entity.Property<DateTime>("SysStartTime").ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                entity.Property<DateTime>("SysEndTime").ValueGeneratedOnAddOrUpdate().Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
            }

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        }
    }
}
