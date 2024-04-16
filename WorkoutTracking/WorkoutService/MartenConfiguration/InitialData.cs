using Marten;
using Marten.Schema;
using WorkoutService.Models;

namespace WorkoutService.MartenConfiguration;

public class InitialData : IInitialData
{
    private readonly object[] _initialData;

    public InitialData(params object[] initialData)
    {
        _initialData = initialData;
    }

    public async Task Populate(IDocumentStore store, CancellationToken cancellation)
    {
        await using var session = store.LightweightSession();
        session.Store(_initialData);
        await session.SaveChangesAsync();
    }
}
public static class InitialDatasets
{
    public static readonly Workout[] workouts =
    {
        new Workout { Id = Guid.Parse("2219b6f7-7883-4629-95d5-1a8a6c74b244"), Name = "Push" },
        new Workout { Id = Guid.Parse("642a3e95-5875-498e-8ca0-93639ddfebcd"), Name = "Pull" }
    };

    //public static readonly User[] Users =
    //{
    //    new User { Id = Guid.Parse("331c15b4-b7bd-44d6-a804-b6879f99a65f"),FirstName = "Danger" , LastName = "Mouse" }
    //};
}
