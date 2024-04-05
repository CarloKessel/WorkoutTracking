using Marten;
using WorkoutService.Interfaces;
using WorkoutService.Models;

namespace WorkoutService.DAL;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly IDocumentStore _store;

    public WorkoutRepository(IDocumentStore store)
    {
        _store = store;
    }

    public async Task<Guid> CreateWorkout(Workout workout, CancellationToken cancellationToken)
    {
        await using var session = _store.LightweightSession();
        session.Store(workout);
        await session.SaveChangesAsync();
        return workout.Id;
    }
}
