using Application.Interfaces;
using Application.Context;
using Application.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Application.DataAccess;

namespace Application.Extensions;

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
                string sql = "INSERT INTO \"Workouts\" (\"Id\", \"UserEmail\", \"Name\", \"Type\", \"DateCreated\") VALUES (1, 'carlovankessel@gmail.com', 'PPL', 0, '" + DateTime.UtcNow.ToString() + "');";
                context.Database.ExecuteSqlRaw(sql);
            }
        }

        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();

        return services;
    }
}
