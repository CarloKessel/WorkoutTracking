using Domain.Models;

namespace Application.Interfaces;

public interface IExerciseRepository
{
    public Task<int> CreateExercise(Exercise exercise, CancellationToken cancellationToken);
    public Task DeleteExercise(int exerciseId, CancellationToken cancellationToken);
}
