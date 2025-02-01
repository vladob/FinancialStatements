﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using FsDataAccess.Cache;
using FsDataAccess.Configurations;
using FsDataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace FsDataAccess.Models;

public partial class FinancialStatementsContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public FinancialStatementsContext(DbContextOptions<FinancialStatementsContext> options, IConfiguration configuration, ILogger<FinancialStatementsContext> logger)
        : base(options)
    {
        _configuration = configuration;
        _logger = logger;
    }
    public async Task InitializeAsync()
    {
        await ClassificationCache.LoadCacheAsync(this, _logger);
    }

    public FinancialStatementsContext()
    {
    }

    public FinancialStatementsContext(DbContextOptions<FinancialStatementsContext> options)
        : base(options)
    {
        // Initialize _configuration with a default value or throw an exception
        _configuration = new ConfigurationBuilder().Build();
    }
/*
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
*/
    // Staging tables
  //  public DbSet<AccountingEntity> StagingAccountingEntities { get; set; }
//    public DbSet<AnnualReport> StagingAnnualReports { get; set; }
    //public DbSet<AnnualReportAttachment> StagingAnnualReportAttachments { get; set; }
//    public DbSet<Attachment> StagingAttachments { get; set; }
//    public DbSet<FinancialReport> StagingFinancialReports { get; set; }
    public DbSet<FinancialReportTemplateStaging> FinancialReportTemplateStaging { get; set; }
//    public DbSet<FinancialStatement> StagingFinancialStatements { get; set; }
    public DbSet<LegalForm> StagingLegalForms { get; set; }
    public DbSet<Location> StagingLocations { get; set; }
    public DbSet<OrganizationSize> StagingOrganizationSizes { get; set; }
    public DbSet<OwnershipType> StagingOwnershipTypes { get; set; }
//    public DbSet<ReportContent> StagingReportContents { get; set; }
//    public DbSet<ReportTable> StagingReportTables { get; set; }
    public DbSet<SkNace> StagingSkNaces { get; set; }
    public DbSet<TemplateHeader> StagingTemplateHeaders { get; set; }
    public DbSet<TemplateRow> StagingTemplateRows { get; set; }
    public DbSet<TemplateTable> StagingTemplateTables { get; set; }

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
        // Apply main table configurations
/*
        modelBuilder.ApplyConfiguration(new AccountingEntityConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new AnnualReportConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new AnnualReportAttachmentConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new AttachmentConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new FinancialReportConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new FinancialReportTemplateConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new FinancialStatementConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new LegalFormConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new LocationConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new OrganizationSizeConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new OwnershipTypeConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new ReportContentConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new ReportTableConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new SkNaceConfiguration("Classifications"));
        modelBuilder.ApplyConfiguration(new TemplateHeaderConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new TemplateRowConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new TemplateTableConfiguration("dbo"));
*/

        // Apply staging table configurations
//        modelBuilder.ApplyConfiguration(new AccountingEntityConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new AnnualReportConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new AnnualReportAttachmentConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new AttachmentConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new FinancialReportConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new FinancialReportTemplateStagingConfiguration());
//        modelBuilder.ApplyConfiguration(new FinancialStatementConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new LegalFormStagingConfiguration());
        modelBuilder.ApplyConfiguration(new LocationStagingConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationSizeStagingConfiguration());
        modelBuilder.ApplyConfiguration(new OwnershipTypeStagingConfiguration());
//        modelBuilder.ApplyConfiguration(new ReportContentConfiguration("staging"));
//        modelBuilder.ApplyConfiguration(new ReportTableConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new SkNaceStagingConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateHeaderStagingConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateRowStagingConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateTableStagingConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
