using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class TemplateRowConfiguration : IEntityTypeConfiguration<TemplateRow>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public TemplateRowConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<TemplateRow> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_TemplateRows");

            entity.Property(e => e.Code).HasMaxLength(100).IsUnicode(false).HasColumnName("code");
            entity.Property(e => e.DescriptionSk).IsUnicode(false).HasColumnName("descriptionSk");
            entity.Property(e => e.DescriptionEn).IsUnicode(false).HasColumnName("descriptionEn");
            entity.Property(e => e.RowNumber).HasColumnName("rowNumber");

            entity.HasOne(d => d.TemplateTable).WithMany(p => p.TemplateRows)
                .HasForeignKey(d => d.TemplateTableId)
                .HasConstraintName("FK__TemplateR__Templ__536D5C82");
        }
    }
}
