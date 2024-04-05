using WorkoutService.Models;

namespace WorkoutService.Interfaces;

public interface IWorkoutRepository
{
    public Task<Guid> CreateWorkout(Workout workout, CancellationToken cancellationToken);
}
