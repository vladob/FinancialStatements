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

public partial class TemplatesDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public TemplatesDbContext(DbContextOptions<TemplatesDbContext> options, IConfiguration configuration, ILogger<TemplatesDbContext> logger)
        : base(options)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public TemplatesDbContext()
    {
    }

    public TemplatesDbContext(DbContextOptions<TemplatesDbContext> options)
        : base(options)
    {
        // Initialize _configuration with a default value or throw an exception
        _configuration = new ConfigurationBuilder().Build();
    }
    /*
    // Report template tables
    public virtual DbSet<FinancialReportTemplate> FinancialReportTemplates { get; set; }
    public virtual DbSet<TemplateHeader> TemplateHeaders { get; set; }
    public virtual DbSet<TemplateRow> TemplateRows { get; set; }
    public virtual DbSet<TemplateTable> TemplateTables { get; set; }
    */
    // Staging tables
    public DbSet<FinancialReportTemplateStaging> StagingFinancialReportTemplate { get; set; }
    public DbSet<TemplateHeaderStaging> StagingTemplateHeaders { get; set; }
    public DbSet<TemplateRowStaging> StagingTemplateRows { get; set; }
    public DbSet<TemplateTableStaging> StagingTemplateTables { get; set; }

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
        modelBuilder.ApplyConfiguration(new FinancialReportTemplateConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new TemplateHeaderConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new TemplateRowConfiguration("dbo"));
        modelBuilder.ApplyConfiguration(new TemplateTableConfiguration("dbo"));
*/

        // Apply staging table configurations
        modelBuilder.ApplyConfiguration(new FinancialReportTemplateStagingConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateTableStagingConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateHeaderStagingConfiguration());
        modelBuilder.ApplyConfiguration(new TemplateRowStagingConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
