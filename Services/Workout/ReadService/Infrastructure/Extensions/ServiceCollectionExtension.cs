using Application.Interfaces;
using Infrastructure.Context;
using Infrastructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, bool isDevelopment)
    {
        services.AddDbContext<WTContext>(options =>
            options.UseNpgsql(configuration.GetSection("Database")["DatabasConnectionString"]!));

        // Apply migrations during application startup
        using (var serviceProvider = services.BuildServiceProvider())
        {
            using (var context = serviceProvider.GetRequiredService<WTContext>())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                context.Database.Migrate();
                string sql = "INSERT INTO \"Workouts\" (\"Id\", \"UserEmail\", \"Name\", \"Type\", \"DateCreated\") VALUES (1, 'test@gmail.com', 'PPL', 0, '" + DateTime.UtcNow.ToString() + "');";
                context.Database.ExecuteSqlRaw(sql);
            }
        }

        services.AddScoped<IWorkoutRepository, WorkoutRepository>();

        return services;
    }
}
