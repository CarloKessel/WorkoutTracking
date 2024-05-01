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
        var workout = session.Load<Workout>(workoutId);
        return workout ?? throw new Exception("Did not find workout.");
    }

    public async Task<List<Workout>> ListAllWorkoutsFromUserId(string UserEmail, CancellationToken cancellationToken)
    {
        await using var session = _store.QuerySession();
        var workouts = session.Query<Workout>().Where(x => x.UserEmail == UserEmail).ToList();
        return workouts ?? throw new Exception("Did not find User workouts.");
    }
}
