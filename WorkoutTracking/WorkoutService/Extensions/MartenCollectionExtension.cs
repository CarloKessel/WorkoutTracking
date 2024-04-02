using Marten;
using Weasel.Core;

namespace WorkoutService.Extensions;

public static class MartenCollectionExtension
{
    public static IServiceCollection AddMartenConfiguration(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        services.AddMarten(options =>
        {
            options.Connection(configuration.GetSection("Database")["DatabasConnectionString"]!);
            if (isDevelopment)
            {
                options.AutoCreateSchemaObjects = AutoCreate.All;
            }

            options.UseDefaultSerialization(EnumStorage.AsString);
        }).ApplyAllDatabaseChangesOnStartup();

        return services;
    }
}
