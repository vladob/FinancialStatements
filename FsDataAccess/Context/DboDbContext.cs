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

public partial class DboDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public DboDbContext(DbContextOptions<DboDbContext> options, IConfiguration configuration, ILogger<DboDbContext> logger)
        : base(options)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public DboDbContext()
    {
    }

    public DboDbContext(DbContextOptions<DboDbContext> options)
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
    public virtual DbSet<FinancialStatement> FinancialStatements { get; set; }
    public virtual DbSet<ReportContent> ReportContents { get; set; }
    public virtual DbSet<ReportTable> ReportTables { get; set; }
*/
    // Staging tables
      public DbSet<AccountingEntity> StagingAccountingEntities { get; set; }
      public DbSet<AnnualReport> StagingAnnualReports { get; set; }
      public DbSet<AnnualReportAttachment> StagingAnnualReportAttachments { get; set; }
      public DbSet<Attachment> StagingAttachments { get; set; }
      public DbSet<FinancialReport> StagingFinancialReports { get; set; }
      public DbSet<FinancialStatement> StagingFinancialStatements { get; set; }
      public DbSet<ReportContent> StagingReportContents { get; set; }
      public DbSet<ReportTable> StagingReportTables { get; set; }


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
        modelBuilder.ApplyConfiguration(new FinancialStatementConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new ReportContentConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new ReportTableConfiguration("dbo"));
*/

        // Apply staging table configurations
        modelBuilder.ApplyConfiguration(new AccountingEntityConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new AnnualReportConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new AnnualReportAttachmentConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new AttachmentConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new FinancialReportConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new FinancialStatementConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new ReportContentConfiguration("staging"));
        modelBuilder.ApplyConfiguration(new ReportTableConfiguration("staging"));


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
