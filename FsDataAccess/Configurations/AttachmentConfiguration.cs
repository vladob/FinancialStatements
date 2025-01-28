using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FsDataAccess.Configurations
{
    public class AttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        private readonly string _schema;
        private readonly bool _useHistoryTable;

        public AttachmentConfiguration(string schema, bool useHistoryTable = false)
        {
            _schema = schema;
            _useHistoryTable = useHistoryTable;
        }

        public void Configure(EntityTypeBuilder<Attachment> entity)
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo_Attachments");

            entity.Property(e => e.Digest)
                .HasMaxLength(64)
                .IsUnicode(false)
                .HasColumnName("digest");
            entity.Property(e => e.Language)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("language");
            entity.Property(e => e.MimeType)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("mimeType");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.PageCount).HasColumnName("pageCount");
            entity.Property(e => e.Size).HasColumnName("size");

            entity.HasOne(d => d.FinancialReport).WithMany(p => p.Attachments)
                .HasForeignKey(d => d.FinancialReportId)
                .HasConstraintName("FK__Attachmen__Finan__405A880E");
        }
    }
}
