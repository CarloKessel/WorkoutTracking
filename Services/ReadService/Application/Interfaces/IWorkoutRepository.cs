using Domain.Models;

namespace Application.Interfaces;

public interface IWorkoutRepository
{
    public Task<Workout> GetWorkoutById(int workoutId, CancellationToken cancellationToken);
    public Task<List<Workout>> ListAllWorkoutsFromUserId(string UserEmail, CancellationToken cancellationToken);
}
