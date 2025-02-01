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

public partial class ClassificationsDbContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public ClassificationsDbContext(DbContextOptions<ClassificationsDbContext> options, IConfiguration configuration, ILogger<ClassificationsDbContext> logger)
        : base(options)
    {
        _configuration = configuration;
        _logger = logger;
    }
    public async Task InitializeAsync()
    {
        await ClassificationCache.LoadCacheAsync(this, _logger);
    }

    public ClassificationsDbContext()
    {
    }

    public ClassificationsDbContext(DbContextOptions<ClassificationsDbContext> options)
        : base(options)
    {
        // Initialize _configuration with a default value or throw an exception
        _configuration = new ConfigurationBuilder().Build();
    }
/*
    // Classification tables
    public virtual DbSet<LegalForm> LegalForms { get; set; }
    public virtual DbSet<Location> Locations { get; set; }
    public virtual DbSet<OrganizationSize> OrganizationSizes { get; set; }
    public virtual DbSet<OwnershipType> OwnershipTypes { get; set; }
    public virtual DbSet<SkNace> SkNaces { get; set; }
*/
    // Staging tables
    public DbSet<LegalFormStaging> StagingLegalForms { get; set; }
    public DbSet<LocationStaging> StagingLocations { get; set; }
    public DbSet<OrganizationSizeStaging> StagingOrganizationSizes { get; set; }
    public DbSet<OwnershipTypeStaging> StagingOwnershipTypes { get; set; }
    public DbSet<SkNaceStaging> StagingSkNaces { get; set; }

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
        base.OnModelCreating(modelBuilder);
        // Apply main table configurations
        /*
                modelBuilder.ApplyConfiguration(new LegalFormConfiguration("Classifications"));
                modelBuilder.ApplyConfiguration(new LocationConfiguration("Classifications"));
                modelBuilder.ApplyConfiguration(new OrganizationSizeConfiguration("Classifications"));
                modelBuilder.ApplyConfiguration(new OwnershipTypeConfiguration("Classifications"));
                modelBuilder.ApplyConfiguration(new SkNaceConfiguration("Classifications"));

        */
        // Apply staging table configurations
        modelBuilder.ApplyConfiguration(new LegalFormStagingConfiguration());
        modelBuilder.ApplyConfiguration(new LocationStagingConfiguration());
        modelBuilder.ApplyConfiguration(new OrganizationSizeStagingConfiguration());
        modelBuilder.ApplyConfiguration(new OwnershipTypeStagingConfiguration());
        modelBuilder.ApplyConfiguration(new SkNaceStagingConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
