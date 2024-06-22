using Domain.Models;

namespace Application.Interfaces;

public interface IExerciseRepository
{
    public Task<List<Exercise>> GetExercisesByWorkoutId(Guid workoutId, CancellationToken cancellationToken);
    public Task CreateExercise(Exercise exercise, CancellationToken cancellationToken);
    public Task DeleteExercise(Guid exerciseId, CancellationToken cancellationToken);
}
