using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using FsDataAccess.Cache;
using FsDataAccess.Configurations;
using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FsDataAccess.Models;

public partial class DboContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    private static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder =>
    {
        builder
            .AddFilter((category, level) =>
                category == DbLoggerCategory.Database.Command.Name
                && level == LogLevel.Information)
            .AddConsole(); // Or any other logger
    });

    public DboContext(DbContextOptions<DboContext> options, IConfiguration configuration, ILogger<DboContext> logger)
        : base(options)
    {
        _configuration = configuration;
        _logger = logger;
    }
	public async Task InitializeAsync()
    {
        await ClassificationCache.LoadCacheAsync(this, _logger);
    } 

    public DboContext()
    {
    }

    public DboContext(DbContextOptions<DboContext> options)
        : base(options)
    {
        // Initialize _configuration with a default value or throw an exception
        _configuration = new ConfigurationBuilder().Build();
    }
/*
	// Dbo tables    
	public virtual DbSet<AccountingEntity> AccountingEntities { get; set; }
    public virtual DbSet<AnnualReport> AnnualReports { get; set; }
    public virtual DbSet<AnnualReportAttachment> AnnualReportAttachments { get; set; }
    public virtual DbSet<Attachment> Attachments { get; set; }
    public virtual DbSet<FinancialReport> FinancialReports { get; set; }
    public virtual DbSet<FinancialStatement> FinancialStatements { get; set; }
    public virtual DbSet<ReportContent> ReportContents { get; set; }
    public virtual DbSet<ReportTable> ReportTables { get; set; }
	
	// Template tables
    public virtual DbSet<FinancialReportTemplate> FinancialReportTemplates { get; set; }
    public virtual DbSet<TemplateHeader> TemplateHeaders { get; set; }
    public virtual DbSet<TemplateRow> TemplateRows { get; set; }
    public virtual DbSet<TemplateTable> TemplateTables { get; set; }

    // Classification tables
    public virtual DbSet<LegalForm> LegalForms { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<OrganizationSize> OrganizationSizes { get; set; }
    public virtual DbSet<OwnershipType> OwnershipTypes { get; set; }
    public virtual DbSet<SkNace> SkNaces { get; set; }
*/

    // Staging tables
	// For dbo tables
      public DbSet<AccountingEntityStaging> StagingAccountingEntities { get; set; }
      public DbSet<AnnualReportStaging> StagingAnnualReports { get; set; }
//      public DbSet<AnnualReportAttachment> StagingAnnualReportAttachments { get; set; }
//      public DbSet<Attachment> StagingAttachments { get; set; }
//      public DbSet<FinancialReportStaging> StagingFinancialReports { get; set; }
      public DbSet<FinancialStatementStaging> StagingFinancialStatements { get; set; }
//      public DbSet<ReportContent> StagingReportContents { get; set; }
//      public DbSet<ReportTable> StagingReportTables { get; set; }

	// For template tables
        public DbSet<FinancialReportTemplateStaging> StagingFinancialReportTemplate { get; set; }
//    public DbSet<TemplateHeaderStaging> StagingTemplateHeaders { get; set; }
//    public DbSet<TemplateRowStaging> StagingTemplateRows { get; set; }
//    public DbSet<TemplateTableStaging> StagingTemplateTables { get; set; }

	// For classification tables
    public DbSet<LegalFormStaging> StagingLegalForms { get; set; }
    public DbSet<LocationStaging> StagingLocations { get; set; }
    public DbSet<OrganizationSizeStaging> StagingOrganizationSizes { get; set; }
    public DbSet<OwnershipTypeStaging> StagingOwnershipTypes { get; set; }
    public DbSet<SkNaceStaging> StagingSkNaces { get; set; }
    public DbSet<ToRetrieveCinList> ToRetrieveCinList { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("FinancialStatementsDb");
            optionsBuilder.UseSqlServer(connectionString);
        }
        
    optionsBuilder
        .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
        .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply main table configurations
/*
		// For dbo tables
        modelBuilder.ApplyConfiguration(new AccountingEntityConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new AnnualReportConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new AnnualReportAttachmentConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new AttachmentConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new FinancialReportConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new FinancialStatementConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new ReportContentConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new ReportTableConfiguration("dbo"));

		// For Report Template tables
        modelBuilder.ApplyConfiguration(new FinancialReportTemplateConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new TemplateHeaderConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new TemplateRowConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new TemplateTableConfiguration("dbo"));
		
		// For Classification tables
		modelBuilder.ApplyConfiguration(new LegalFormConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new LocationConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new OrganizationSizeConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new OwnershipTypeConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new SkNaceConfiguration("Classifications"));
*/

        // Apply staging table configurations
		// For dbo tables
        modelBuilder.ApplyConfiguration(new AccountingEntityStagingConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new AnnualReportStagingConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new AnnualReportAttachmentConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new AttachmentConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new FinancialReportConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new FinancialStatementStagingConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new ReportContentConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new ReportTableConfiguration("staging"));

		// For template tables
        modelBuilder.ApplyConfiguration(new FinancialReportTemplateStagingConfiguration());
//        modelBuilder.ApplyConfiguration(new TemplateTableStagingConfiguration());
//        modelBuilder.ApplyConfiguration(new TemplateHeaderStagingConfiguration());
//        modelBuilder.ApplyConfiguration(new TemplateRowStagingConfiguration());

		// For classification tables
        modelBuilder.ApplyConfiguration(new LegalFormStagingConfiguration());
        modelBuilder.ApplyConfiguration(new LocationStagingConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationSizeStagingConfiguration());
        modelBuilder.ApplyConfiguration(new OwnershipTypeStagingConfiguration());
        modelBuilder.ApplyConfiguration(new SkNaceStagingConfiguration());

        // Configuration for ToRetrieveCinList entity
        modelBuilder.Entity<ToRetrieveCinList>().HasKey(c => c.CIN);

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
