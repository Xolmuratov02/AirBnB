using AirBnB.Domain.Entities;
using AirBnB.Domain.Enums;
using Newtonsoft.Json;

namespace AirBnB.Api.Data;

public static class SeedDataExtensions
{
    public static async ValueTask SeedDataAsync(this IServiceProvider serviceProvider)
    {
        var dbContext = serviceProvider.GetRequiredService<AppDbContext>();
        var webHostEnvironment = serviceProvider.GetRequiredService<IWebHostEnvironment>();

        if (!await dbContext.Countries.AnyAsync())
            await SeedCountriesAsync(dbContext, webHostEnvironment);

        if (!await dbContext.Cities.AnyAsync())
            await SeedCitiesAsync(dbContext, webHostEnvironment);

        if (!await dbContext.ListingCategories.AnyAsync())
            await SeedListingCategoriesAsync(dbContext, webHostEnvironment);

        if (dbContext.ChangeTracker.HasChanges())
            await dbContext.SaveChangesAsync();
    }

    private static async ValueTask SeedCountriesAsync(AppDbContext dbContext, IHostEnvironment webHostEnvironment)
    {
        var countriesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "Countries.json");

        // Retrieve countries
        var countries = JsonConvert.DeserializeObject<List<Country>>(await File.ReadAllTextAsync(countriesFileName))!;

        await dbContext.Countries.AddRangeAsync(countries);
    }

    private static async ValueTask SeedCitiesAsync(AppDbContext dbContext, IHostEnvironment webHostEnvironment)
    {
        var citiesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "Cities.json");

        // Retrieve cities
        var cities = JsonConvert.DeserializeObject<List<City>>(await File.ReadAllTextAsync(citiesFileName))!;

        await dbContext.Cities.AddRangeAsync(cities);
    }

    private static async ValueTask SeedListingCategoriesAsync(AppDbContext dbContext, IHostEnvironment webHostEnvironment)
    {
        var cities = await dbContext.Cities.ToListAsync();

        var listingCategoriesFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "ListingCategories.json");

        // Retrieve listing categories
        var listingCategories = JsonConvert.DeserializeObject<List<ListingCategory>>(await File.ReadAllTextAsync(listingCategoriesFileName))!;

        // Set category images
        listingCategories.ForEach(
            listingCategory => listingCategory.ImageStorageFile = new StorageFile
            {
                FileName = $"{listingCategory.ImageStorageFileId}.jpg",
                Type = StorageFileType.Image
            }
        );

        var listingsFileName = Path.Combine(webHostEnvironment.ContentRootPath, "Data", "SeedData", "Listings.json");

        // Retrieve listings
        var listings = JsonConvert.DeserializeObject<List<Listing>>(await File.ReadAllTextAsync(listingsFileName))!;


        // validate listing name 
        listings.ForEach(
            listing =>
            {
                if (string.IsNullOrWhiteSpace(listing.Name))
                    throw new Exception($"Listing name is required. Listing: {JsonConvert.SerializeObject(listing)}");
            }
        );

        // Add additional details
        var random = new Random();
        listings.ForEach(
            listing =>
            {
                // Set built year
                listing.BuiltDate = new DateOnly(random.Next(1900, 2021), 1, 1);

                // Set category
                listing.Category = listingCategories.First(listingCategory => listingCategory.Id == listing.CategoryId);

                // Set location
                listing.Address.CityId = !string.IsNullOrWhiteSpace(listing.Address.City)
                    ? cities.FirstOrDefault(city => city.Name.ToLower().Equals(listing.Address.City.ToLower()))?.Id
                    : listing.Address.CityId;

                // Set media
                listing.ImagesStorageFile = listing.ImagesStorageFile.Select(
                        listingMedia =>
                        {
                            listingMedia.StorageFile = new StorageFile
                            {
                                FileName = $"{listingMedia.Id}.jpg",
                                Type = StorageFileType.Image,
                            };

                            return listingMedia;
                        }
                    )
                    .ToList();
            }
        );

        // Add listing categories and listings
        await dbContext.ListingCategories.AddRangeAsync(listingCategories);
        await dbContext.Listings.AddRangeAsync(listings);
    }
}