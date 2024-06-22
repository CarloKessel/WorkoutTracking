using Application.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Polly.Retry;
using Polly;

namespace Infrastructure.DataAccess;

public class ExerciseRepository : IExerciseRepository
{
    private readonly WTContext _context;
    private static readonly AsyncRetryPolicy RetryPolicy = Policy.Handle<DbUpdateException>()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

    public ExerciseRepository(WTContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateExercise(Exercise exercise, CancellationToken cancellationToken)
    {
        await RetryPolicy.ExecuteAsync(async () =>
        {
            await _context.Exercises.AddAsync(exercise, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        });

        return exercise.Id;
    }

    public async Task DeleteExercise(Guid exerciseId, CancellationToken cancellationToken)
    {
        await RetryPolicy.ExecuteAsync(async () =>
        {
            await _context.Exercises.Where(w => w.Id == exerciseId).ExecuteDeleteAsync(cancellationToken);
        });
    }
}
