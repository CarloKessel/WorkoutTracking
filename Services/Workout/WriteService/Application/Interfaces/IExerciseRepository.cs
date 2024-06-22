using Domain.Models;

namespace Application.Interfaces;

public interface IExerciseRepository
{
    public Task<Guid> CreateExercise(Exercise exercise, CancellationToken cancellationToken);
    public Task DeleteExercise(Guid exerciseId, CancellationToken cancellationToken);
}
