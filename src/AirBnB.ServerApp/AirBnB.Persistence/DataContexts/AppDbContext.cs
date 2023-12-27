using AirBnB.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AirBnB.Persistence.DataContexts;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<City> Cities => Set<City>();

    public DbSet<Country> Countries => Set<Country>();

    public DbSet<StorageFile> StorageFiles => Set<StorageFile>();

    public DbSet<ListingCategory> ListingCategories => Set<ListingCategory>();

    public DbSet<Listing> Listings => Set<Listing>();

    public DbSet<ListingMedia> ListingMedias => Set<ListingMedia>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }
}