using AirBnB.Api.Data;
using AirBnB.Persistence.DataContexts;
using AirBnB.Persistence.Repositories;
using AirBnB.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace AirBnB.Api.Configurations;

public static partial class HostConfiguration
{
    private static readonly ICollection<Assembly> Assemblies;

    static HostConfiguration()
    {
        Assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        Assemblies.Add(Assembly.GetExecutingAssembly());
    }

    private static WebApplicationBuilder AddSerializers(this WebApplicationBuilder builder)
    {
        // register json serialization settings
        builder.Services.AddSingleton<IJsonSerializationSettingsProvider, JsonSerializationSettingsProvider>();

        return builder;
    }

    private static WebApplicationBuilder AddMappers(this WebApplicationBuilder builder)
    {
        builder.Services.AddAutoMapper(Assemblies);

        return builder;
    }

    //private static WebApplicationBuilder AddCaching(this WebApplicationBuilder builder)
    //{
    //    // Register cache settings
    //    builder.Services.Configure<CacheSettings>(builder.Configuration.GetSection(nameof(CacheSettings)));

    //    // Register redis cache
    //    builder.Services.AddStackExchangeRedisCache(
    //        options =>
    //        {
    //            options.Configuration = builder.Configuration.GetConnectionString("RedisConnectionString");
    //            options.InstanceName = "Caching.SimpleInfra";
    //        }
    //    );

    //    // Register cache broker
    //    builder.Services.AddSingleton<ICacheBroker, RedisDistributedCacheBroker>();

    //    return builder;
    //}

    private static WebApplicationBuilder AddBusinessLogicInfrastructure(this WebApplicationBuilder builder)
    {
        // register db contexts
        builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

        # region Locations

        // Register repositories
        builder.Services.AddScoped<ICityRepository, CityRepository>().AddScoped<ICountryRepository, CountryRepository>();

        // Register foundation data access services
        builder.Services.AddScoped<ICityService, CityService>().AddScoped<ICountryService, CountryService>();

        #endregion

        #region Listing Categories

        // Register repositories
        builder.Services.AddScoped<IListingCategoryRepository, ListingCategoryRepository>();

        // Register foundation data access services
        builder.Services.AddScoped<IListingCategoryService, ListingCategoryService>();

        #endregion

        #region Storage files

        builder.Services.Configure<StorageFileSettings>(builder.Configuration.GetSection(nameof(StorageFileSettings)))
            .Configure<ApiSettings>(builder.Configuration.GetSection(nameof(ApiSettings)));

        #endregion

        #region Listings

        // Register repositories
        builder.Services.AddScoped<IListingRepository, ListingRepository>();

        // Register foundation data access services
        builder.Services.AddScoped<IListingService, ListingService>();

        // Register orchestration services
        builder.Services.AddScoped<IListingOrchestrationService, ListingOrchestrationService>();

        #endregion

        return builder;
    }

    private static WebApplicationBuilder AddCorsSecurity(this WebApplicationBuilder builder)
    {
        var clientSettings = builder.Configuration.GetSection("ClientSettings").Get<ApiSettings>()!;

        builder.Services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(
                    policyBuilder =>
                    {
                        policyBuilder.WithOrigins(clientSettings.BaseAddress).AllowAnyHeader().AllowAnyMethod().AllowCredentials();
                    }
                );
            }
        );

        return builder;
    }

    private static WebApplicationBuilder AddRequestContextTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddHttpContextAccessor();
        builder.Services.AddScoped<IRequestContextProvider, RequestContextProvider>();

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static async Task<WebApplication> SeedDataAsync(this WebApplication app)
    {
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        using var scope = scopeFactory.CreateScope();
        await scope.ServiceProvider.SeedDataAsync();

        return app;
    }

    private static WebApplication UseMediaInfrastructure(this WebApplication app)
    {
        app.UseStaticFiles();

        return app;
    }

    private static WebApplication UseCorsSecurity(this WebApplication app)
    {
        app.UseCors();

        return app;
    }

    private static async Task<WebApplication> ApplyMigrationsAsync(this WebApplication app)
    {
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        await scopeFactory.MigrateAsync<AppDbContext>();

        return app;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }
}