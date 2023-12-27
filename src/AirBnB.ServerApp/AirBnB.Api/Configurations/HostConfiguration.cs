namespace AirBnB.Api.Configurations;

public static partial class HostConfiguration
{
    public static ValueTask<WebApplicationBuilder> ConfigureAsync(this WebApplicationBuilder builder)
    {
        builder
            .AddSerializers()
            .AddMappers()
            .AddCaching()
            .AddBusinessLogicInfrastructure()
            .AddCorsSecurity()
            .AddRequestContextTools()
            .AddExposers();

        return new(builder);
    }

    public static async ValueTask<WebApplication> ConfigureAsync(this WebApplication app)
    {
        await app.ApplyMigrationsAsync();
        await app.SeedDataAsync();

        app
            .UseCorsSecurity()
            .UseMediaInfrastructure()
            .UseExposers();

        return app;
    }
}