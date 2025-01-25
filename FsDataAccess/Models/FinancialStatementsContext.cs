using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FsDataAccess.Models;

public partial class FinancialStatementsContext : DbContext
{
    private readonly IConfiguration _configuration;

    public FinancialStatementsContext(DbContextOptions<FinancialStatementsContext> options, IConfiguration configuration)
    : base(options)
    {
        _configuration = configuration;
    }

    public FinancialStatementsContext()
    {
    }

    public FinancialStatementsContext(DbContextOptions<FinancialStatementsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AccountingEntity> AccountingEntities { get; set; }

    public virtual DbSet<AnnualReport> AnnualReports { get; set; }

    public virtual DbSet<AnnualReportAttachment> AnnualReportAttachments { get; set; }

    public virtual DbSet<Attachment> Attachments { get; set; }

    public virtual DbSet<FinancialReport> FinancialReports { get; set; }

    public virtual DbSet<FinancialReportTemplate> FinancialReportTemplates { get; set; }

    public virtual DbSet<FinancialStatement> FinancialStatements { get; set; }

    public virtual DbSet<LegalForm> LegalForms { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<OrganizationSize> OrganizationSizes { get; set; }

    public virtual DbSet<OwnershipType> OwnershipTypes { get; set; }

    public virtual DbSet<ReportContent> ReportContents { get; set; }

    public virtual DbSet<ReportTable> ReportTables { get; set; }

    public virtual DbSet<SkNace> SkNaces { get; set; }

    public virtual DbSet<TemplateHeader> TemplateHeaders { get; set; }

    public virtual DbSet<TemplateRow> TemplateRows { get; set; }

    public virtual DbSet<TemplateTable> TemplateTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("FinancialStatementsDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountingEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Accounti__3214EC073904D86B");

            entity.Property(e => e.Cancellation).HasColumnName("cancellation");
            entity.Property(e => e.Cin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("cin");
            entity.Property(e => e.City)
                .HasMaxLength(200)
                .HasColumnName("city");
            entity.Property(e => e.Consolidated).HasColumnName("consolidated");
            entity.Property(e => e.DataSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataSource");
            entity.Property(e => e.DistrictId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("districtId");
            entity.Property(e => e.ErpId)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Established).HasColumnName("established");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.LegalFormId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("legalFormId");
            entity.Property(e => e.OrganizationSizeId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("organizationSizeId");
            entity.Property(e => e.OwnershipTypeId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("ownershipTypeId");
            entity.Property(e => e.RegionId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("regionId");
            entity.Property(e => e.RegisterredOfficeId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("registerredOfficeId");
            entity.Property(e => e.Sid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("sid");
            entity.Property(e => e.SkNaceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("skNaceId");
            entity.Property(e => e.Street)
                .HasMaxLength(200)
                .HasColumnName("street");
            entity.Property(e => e.Tin)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("tin");
            entity.Property(e => e.TitleAe)
                .HasMaxLength(500)
                .HasColumnName("titleAE");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("zip");

            entity.HasMany(d => d.AnnualReports).WithMany(p => p.AccountingEntities)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountingEntitiesAnnualReport",
                    r => r.HasOne<AnnualReport>().WithMany()
                        .HasForeignKey("AnnualReportId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accountin__Annua__5B0E7E4A"),
                    l => l.HasOne<AccountingEntity>().WithMany()
                        .HasForeignKey("AccountingEntityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accountin__Accou__5A1A5A11"),
                    j =>
                    {
                        j.HasKey("AccountingEntityId", "AnnualReportId").HasName("PK__Accounti__72B514D14DD17587");
                        j.ToTable("AccountingEntities_AnnualReports", "indexing");
                    });

            entity.HasMany(d => d.FinancialStatements).WithMany(p => p.AccountingEntities)
                .UsingEntity<Dictionary<string, object>>(
                    "AccountingEntitiesFinancialStatement",
                    r => r.HasOne<FinancialStatement>().WithMany()
                        .HasForeignKey("FinancialStatementId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accountin__Finan__573DED66"),
                    l => l.HasOne<AccountingEntity>().WithMany()
                        .HasForeignKey("AccountingEntityId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__Accountin__Accou__5649C92D"),
                    j =>
                    {
                        j.HasKey("AccountingEntityId", "FinancialStatementId").HasName("PK__Accounti__54B346F8C6389670");
                        j.ToTable("AccountingEntities_FinancialStatements", "indexing");
                    });
        });

        modelBuilder.Entity<AnnualReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnnualRe__3214EC07FEA5418F");

            entity.Property(e => e.AccountingEntityId).HasColumnName("accountingEntityId");
            entity.Property(e => e.AssemblyDate).HasColumnName("assemblyDate");
            entity.Property(e => e.DataAvailability)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataAvailability");
            entity.Property(e => e.DataSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataSource");
            entity.Property(e => e.FundName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fundName");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.LeiCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("leiCode");
            entity.Property(e => e.PeriodFrom)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("periodFrom");
            entity.Property(e => e.PeriodTo)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("periodTo");
            entity.Property(e => e.SubmissionDate).HasColumnName("submissionDate");
            entity.Property(e => e.TitleAe)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("titleAE");
            entity.Property(e => e.Type)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("type");
        });

        modelBuilder.Entity<AnnualReportAttachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AnnualRe__3214EC073D43169B");

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
        });

        modelBuilder.Entity<Attachment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Attachme__3214EC07FF64FE41");

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
        });

        modelBuilder.Entity<FinancialReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Financia__3214EC074D3D46A4");

            entity.Property(e => e.Currency)
                .HasMaxLength(9)
                .IsUnicode(false)
                .HasColumnName("currency");
            entity.Property(e => e.DataAvailability)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataAvailability");
            entity.Property(e => e.DataSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataSource");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.TaxOfficeCode)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasColumnName("taxOfficeCode");

            entity.HasOne(d => d.AnnualReport).WithMany(p => p.FinancialReports)
                .HasForeignKey(d => d.AnnualReportId)
                .HasConstraintName("FK__Financial__Annua__3D7E1B63");

            entity.HasOne(d => d.FinancialStatement).WithMany(p => p.FinancialReports)
                .HasForeignKey(d => d.FinancialStatementId)
                .HasConstraintName("FK__Financial__Finan__3C89F72A");
        });

        modelBuilder.Entity<FinancialReportTemplate>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Financia__3214EC07E1DDA218");

            entity.Property(e => e.DataSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataSource");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.MfSpecification)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("mfSpecification");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.ValidFrom).HasColumnName("validFrom");
            entity.Property(e => e.ValidTo).HasColumnName("validTo");
        });

        modelBuilder.Entity<FinancialStatement>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Financia__3214EC07F57BE0CD");

            entity.Property(e => e.ApprovalDate).HasColumnName("approvalDate");
            entity.Property(e => e.AssemblyDate).HasColumnName("assemblyDate");
            entity.Property(e => e.AuditorReportAttachmentDate).HasColumnName("auditorReportAttachmentDate");
            entity.Property(e => e.Consolidated).HasColumnName("consolidated");
            entity.Property(e => e.ConsolidatedCentralGovernment).HasColumnName("consolidatedCentralGovernment");
            entity.Property(e => e.DataSource)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("dataSource");
            entity.Property(e => e.FundName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fundName");
            entity.Property(e => e.LastModification).HasColumnName("lastModification");
            entity.Property(e => e.LeiCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("leiCode");
            entity.Property(e => e.PeriodFrom)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("periodFrom");
            entity.Property(e => e.PeriodTo)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("periodTo");
            entity.Property(e => e.PreparationDate).HasColumnName("preparationDate");
            entity.Property(e => e.SubmissionDate).HasColumnName("submissionDate");
            entity.Property(e => e.SummaryPublicAdministration).HasColumnName("summaryPublicAdministration");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("type");

            entity.HasOne(d => d.AccountingEntity).WithMany(p => p.FinancialStatementsNavigation)
                .HasForeignKey(d => d.AccountingEntityId)
                .HasConstraintName("FK__Financial__Accou__37C5420D");
        });

        modelBuilder.Entity<LegalForm>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LegalFor__3214EC07F36C1935");

            entity
                .ToTable("LegalForms", "Classifications")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("LegalFormsHistory", "Classifications");
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
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Location__3214EC07462F5209");

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
        });

        modelBuilder.Entity<OrganizationSize>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Organiza__3214EC0773E6DA1A");

            entity
                .ToTable("OrganizationSizes", "Classifications")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("OrganizationSizesHistory", "Classifications");
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
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        });

        modelBuilder.Entity<OwnershipType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ownershi__3214EC0753CF017D");

            entity
                .ToTable("OwnershipTypes", "Classifications")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("OwnershipTypesHistory", "Classifications");
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
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        });

        modelBuilder.Entity<ReportContent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReportCo__3214EC07737E44EF");

            entity.Property(e => e.ApprovalDate).HasColumnName("approvalDate");
            entity.Property(e => e.AssemblyDate).HasColumnName("assemblyDate");
            entity.Property(e => e.AuditorReportAttachmentDate).HasColumnName("auditorReportAttachmentDate");
            entity.Property(e => e.CommercialRegister)
                .IsUnicode(false)
                .HasColumnName("commercialRegister");
            entity.Property(e => e.CompletionDate).HasColumnName("completionDate");
            entity.Property(e => e.CoverPageAddress)
                .IsUnicode(false)
                .HasColumnName("coverPageAddress");
            entity.Property(e => e.CoverPageConsolidated).HasColumnName("coverPageConsolidated");
            entity.Property(e => e.CoverPageConsolidatedCg).HasColumnName("coverPageConsolidatedCG");
            entity.Property(e => e.CoverPageDic)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("coverPageDic");
            entity.Property(e => e.CoverPageIco)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("coverPageIco");
            entity.Property(e => e.CoverPageLegalFormId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("coverPageLegalFormId");
            entity.Property(e => e.CoverPageSid)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("coverPageSid");
            entity.Property(e => e.CoverPageSkNaceId)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("coverPageSkNaceId");
            entity.Property(e => e.CoverPageSummaryPa).HasColumnName("coverPageSummaryPA");
            entity.Property(e => e.CoverPageTitle)
                .IsUnicode(false)
                .HasColumnName("coverPageTitle");
            entity.Property(e => e.CoverPageType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("coverPageType");
            entity.Property(e => e.CoverPageTypeUnit)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("coverPageTypeUnit");
            entity.Property(e => e.FundName)
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasColumnName("fundName");
            entity.Property(e => e.LeiCode)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("leiCode");
            entity.Property(e => e.PeriodFrom)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("periodFrom");
            entity.Property(e => e.PeriodTo)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("periodTo");
            entity.Property(e => e.PreparationDate).HasColumnName("preparationDate");
            entity.Property(e => e.PreviousPeriodFrom)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("previousPeriodFrom");
            entity.Property(e => e.PreviousPeriodTo)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("previousPeriodTo");

            entity.HasOne(d => d.FinancialReport).WithMany(p => p.ReportContents)
                .HasForeignKey(d => d.FinancialReportId)
                .HasConstraintName("FK__ReportCon__Finan__4336F4B9");
        });

        modelBuilder.Entity<ReportTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReportTa__3214EC07EEA6A9AE");

            entity.Property(e => e.Data)
                .HasColumnType("money")
                .HasColumnName("data");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.FinancialReport).WithMany(p => p.ReportTables)
                .HasForeignKey(d => d.FinancialReportId)
                .HasConstraintName("FK__ReportTab__Finan__46136164");
        });

        modelBuilder.Entity<SkNace>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__SkNace__3214EC0763C3F0C0");

            entity
                .ToTable("SkNace", "Classifications")
                .ToTable(tb => tb.IsTemporal(ttb =>
                    {
                        ttb.UseHistoryTable("SkNaceHistory", "Classifications");
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
            entity.Property(e => e.TitleEng).HasMaxLength(250);
            entity.Property(e => e.TitleSk).HasMaxLength(250);
        });

        modelBuilder.Entity<TemplateHeader>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Template__3214EC07B18EC648");

            entity.Property(e => e.ColumnPosition).HasColumnName("columnPosition");
            entity.Property(e => e.ColumnSpan).HasColumnName("columnSpan");
            entity.Property(e => e.RowPosition).HasColumnName("rowPosition");
            entity.Property(e => e.RowSpan).HasColumnName("rowSpan");
            entity.Property(e => e.Text)
                .IsUnicode(false)
                .HasColumnName("text");

            entity.HasOne(d => d.TemplateTable).WithMany(p => p.TemplateHeaders)
                .HasForeignKey(d => d.TemplateTableId)
                .HasConstraintName("FK__TemplateH__Templ__5090EFD7");
        });

        modelBuilder.Entity<TemplateRow>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Template__3214EC074E699507");

            entity.Property(e => e.Code)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("code");
            entity.Property(e => e.Description)
                .IsUnicode(false)
                .HasColumnName("description");
            entity.Property(e => e.RowNumber).HasColumnName("rowNumber");

            entity.HasOne(d => d.TemplateTable).WithMany(p => p.TemplateRows)
                .HasForeignKey(d => d.TemplateTableId)
                .HasConstraintName("FK__TemplateR__Templ__536D5C82");
        });

        modelBuilder.Entity<TemplateTable>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Template__3214EC07CAD38B8F");

            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.FinancialReportTemplate).WithMany(p => p.TemplateTables)
                .HasForeignKey(d => d.FinancialReportTemplateId)
                .HasConstraintName("FK__TemplateT__Finan__4DB4832C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
