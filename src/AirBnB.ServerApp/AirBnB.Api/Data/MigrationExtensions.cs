using System;

namespace AirBnB.Api.Data;

public static class MigrationExtensions
{
    public static async ValueTask MigrateAsync(this IServiceProvider serviceProvider)
    {
        var context = serviceProvider.GetRequiredService<AppDbContext>();

        if ((await context.Database.GetPendingMigrationsAsync()).Any())
            await context.Database.MigrateAsync();
    }
}