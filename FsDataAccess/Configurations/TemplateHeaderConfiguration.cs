using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class TemplateHeaderConfiguration : IEntityTypeConfiguration<TemplateHeader>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public TemplateHeaderConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<TemplateHeader> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_TemplateHeaders");

            entity.Property(e => e.ErpId).HasColumnName("ErpId");
            entity.Property(e => e.ColumnPosition).HasColumnName("columnPosition");
            entity.Property(e => e.ColumnSpan).HasColumnName("columnSpan");
            entity.Property(e => e.RowPosition).HasColumnName("rowPosition");
            entity.Property(e => e.RowSpan).HasColumnName("rowSpan");
            entity.Property(e => e.TextSk).IsUnicode(false).HasColumnName("textSk");
            entity.Property(e => e.TextEn).IsUnicode(false).HasColumnName("textEn");

            entity.HasOne(d => d.TemplateTable).WithMany(p => p.TemplateHeaders)
                .HasForeignKey(d => d.TemplateTableId)
                .HasConstraintName("FK__TemplateH__Templ__5090EFD7");
        }
    }
}
