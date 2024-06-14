using Domain.Models;

namespace Application.Interfaces;

public interface IWorkoutRepository
{
    public Task<int> CreateWorkout(Workout workout, CancellationToken cancellationToken);
}
