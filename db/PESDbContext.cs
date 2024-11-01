using System;
using Microsoft.EntityFrameworkCore;
using PropertyErrandsService.db.entities;
using PropertyErrandsService.db.models;

namespace PropertyErrandsService.db;

public class PESDbContext : DbContext
{
    public DbSet<Property> Properties { get; set; }
    public DbSet<Building> Buildings { get; set; }
    public DbSet<Unit> Units { get; set; }
    public DbSet<Tenant> Tenants { get; set; }
    public DbSet<MaintenanceJob> MaintenanceJobs { get; set; }
    public DbSet<Supplier> Suppliers { get; set; }

    public string DbPath { get; set; }

    public PESDbContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "PropertyErrandService.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={DbPath}");
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<MaintenanceJob>()
            .Property(mj => mj.MaintenanceJobStatusId)
            .HasConversion<int>();

        builder.Entity<MaintenanceJobStatus>()
        .Property(mjs => mjs.MaintenanceJobStatusId)
        .HasConversion<int>();

        builder.Entity<MaintenanceJobStatus>()
            .HasData(Enum.GetValues(typeof(MaintenanceJobStatusId))
            .Cast<MaintenanceJobStatusId>()
            .Select(mjsId => new MaintenanceJobStatus{ MaintenanceJobStatusId = mjsId, Name = mjsId.ToString() })
        );
    }
}
