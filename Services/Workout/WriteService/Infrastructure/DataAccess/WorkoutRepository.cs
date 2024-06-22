using Application.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Retry;

namespace Infrastructure.DataAccess;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly WTContext _context;
    private static readonly AsyncRetryPolicy RetryPolicy = Policy.Handle<DbUpdateException>()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));


    public WorkoutRepository(WTContext context)
    {
        _context = context;
    }

    public async Task<Guid> CreateWorkout(Workout workout, CancellationToken cancellationToken)
    {
        await RetryPolicy.ExecuteAsync(async () =>
        {
            await _context.Workouts.AddAsync(workout, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        });

        return workout.Id;
    }

    public async Task DeleteWorkout(Guid workoutId, CancellationToken cancellationToken)
    {
        await RetryPolicy.ExecuteAsync(async () =>
        {
            await _context.Workouts.Where(w => w.Id == workoutId).ExecuteDeleteAsync(cancellationToken);
        });
    }
}