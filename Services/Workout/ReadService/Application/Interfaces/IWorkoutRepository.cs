using Domain.Models;

namespace Application.Interfaces;

public interface IWorkoutRepository
{
    public Task<Workout> GetWorkoutById(Guid workoutId, CancellationToken cancellationToken);
    public Task<List<Workout>> ListAllWorkoutsFromUserEmail(string UserEmail, CancellationToken cancellationToken);
    public Task CreateWorkout(Workout workout, CancellationToken cancellationToken);
    public Task DeleteWorkout(Guid workoutId, CancellationToken cancellationToken);
}
