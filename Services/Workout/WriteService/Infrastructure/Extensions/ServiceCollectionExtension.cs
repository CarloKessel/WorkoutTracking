using Application.Interfaces;
using Domain.Models;
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

        services.AddScoped<IWorkoutRepository, WorkoutRepository>();
        services.AddScoped<IExerciseRepository, ExerciseRepository>();

        ApplyMigrations(services);

        return services;
    }

    private static void ApplyMigrations(IServiceCollection services)
    {
        // Apply migrations during application startup
        using (var serviceProvider = services.BuildServiceProvider())
        {
            using (var scope = serviceProvider.CreateScope())
            {
                using (var context = serviceProvider.GetRequiredService<WTContext>())
                {
                    context.Database.EnsureCreated();
                    //context.Database.Migrate();

                    // Insert initial data if necessary
                    if (!context.Workouts.Any())
                    {
                        context.Workouts.Add(new Workout
                        {
                            Id = Guid.Parse("efec1544-4518-47ce-9908-2389cb121382"),
                            UserEmail = "test@gmail.com",
                            Name = "PPL",
                            Type = 0,
                            DateCreated = DateTime.UtcNow
                        });
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}
