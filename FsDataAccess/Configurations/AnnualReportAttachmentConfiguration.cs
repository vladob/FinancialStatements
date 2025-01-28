using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class AnnualReportAttachmentConfiguration : IEntityTypeConfiguration<AnnualReportAttachment>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public AnnualReportAttachmentConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<AnnualReportAttachment> entity)
        {
            entity.ToTable("AnnualReportAttachments", _schema);

            entity.HasKey(e => e.Id).HasName("PK_dbo_AnnualReportAttachments");

            entity.Property(e => e.Digest)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("digest");
            entity.Property(e => e.MimeType)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("mimeType");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Size).HasColumnName("size");

            entity.HasOne(d => d.AnnualReport).WithMany(p => p.AnnualReportAttachments)
                .HasForeignKey(d => d.AnnualReportId)
                .HasConstraintName("FK__AnnualRep__Annua__48EFCE0F");
        }
    }
}
