using Domain.Models;

namespace Application.Interfaces;

public interface IWorkoutRepository
{
    public Task<Guid> CreateWorkout(Workout workout, CancellationToken cancellationToken);
    public Task DeleteWorkout(Guid workoutId, CancellationToken cancellationToken);
}
