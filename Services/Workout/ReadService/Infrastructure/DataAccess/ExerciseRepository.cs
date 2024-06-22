using Application.Interfaces;
using Domain.Models;
using Application.Context;
using Microsoft.EntityFrameworkCore;
using Polly.Retry;
using Polly;

namespace Application.DataAccess;

public class ExerciseRepository : IExerciseRepository
{
    private readonly WTContext _context;
    private static readonly AsyncRetryPolicy RetryPolicy = Policy.Handle<DbUpdateException>()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

    public ExerciseRepository(WTContext context)
    {
        _context = context;
    }

    public async Task<List<Exercise>> GetExercisesByWorkoutId(Guid workoutId, CancellationToken cancellationToken)
    {
        return await RetryPolicy.ExecuteAsync(async () =>
        {
            return await _context.Exercises.Where(e => e.WorkoutId == workoutId).ToListAsync();
        });
    }

    public async Task CreateExercise(Exercise exercise, CancellationToken cancellationToken)
    {
        await RetryPolicy.ExecuteAsync(async () =>
        {
            await _context.Exercises.AddAsync(exercise, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        });

        Console.WriteLine($"Exercise created with id: {exercise.Id}");
    }

    public async Task DeleteExercise(Guid exerciseId, CancellationToken cancellationToken)
    {
        await RetryPolicy.ExecuteAsync(async () =>
        {
            await _context.Exercises.Where(w => w.Id == exerciseId).ExecuteDeleteAsync(cancellationToken);
        });
    }
}
