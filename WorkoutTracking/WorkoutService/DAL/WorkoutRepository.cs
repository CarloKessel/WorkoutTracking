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

    public async Task<Workout> GetWorkoutById(Guid workoutId, CancellationToken cancellationToken)
    {
        await using var session = _store.QuerySession();
        Console.WriteLine(workoutId.ToString());
        var workout = session.Load<Workout>(workoutId);
        Console.WriteLine(workout.Id.ToString());
        Console.WriteLine(workout.Name);
        return workout ?? throw new Exception("Did not find workout.");
    }
}
