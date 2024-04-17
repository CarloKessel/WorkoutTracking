using WorkoutService.Models;

namespace WorkoutService.Interfaces;

public interface IWorkoutRepository
{
    public Task<Guid> CreateWorkout(Workout workout, CancellationToken cancellationToken);
    public Task<Workout> GetWorkoutById(Guid workoutId, CancellationToken cancellationToken);
    public Task<List<Workout>> ListAllWorkoutsFromUserId(Guid userId, CancellationToken cancellationToken);
}
