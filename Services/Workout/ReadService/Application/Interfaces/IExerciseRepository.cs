using Domain.Models;

namespace Application.Interfaces;

public interface IExerciseRepository
{
    public Task<List<Exercise>> GetExercisesByWorkoutId(int workoutId, CancellationToken cancellationToken);
    public Task CreateExercise(Exercise exercise, CancellationToken cancellationToken);
    public Task DeleteExercise(int exerciseId, CancellationToken cancellationToken);
}
