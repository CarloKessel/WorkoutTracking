using Application.Interfaces;
using Domain.Models;
using Application.Context;
using Microsoft.EntityFrameworkCore;
using Polly.Retry;
using Polly;

namespace Application.DataAccess;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly WTContext _context;
    private static readonly AsyncRetryPolicy RetryPolicy = Policy.Handle<DbUpdateException>()
        .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

    public WorkoutRepository(WTContext context)
    {
        _context = context;
    }

    public async Task<Workout> GetWorkoutById(Guid workoutId, CancellationToken cancellationToken)
    {
        return await RetryPolicy.ExecuteAsync(async () =>
        {
            var workout = await _context.Workouts.FindAsync(workoutId, cancellationToken);
            return workout ?? throw new Exception("Did not find workout.");
        });
    }

    public async Task<List<Workout>> ListAllWorkoutsFromUserEmail(string UserEmail, CancellationToken cancellationToken)
    {
        return await RetryPolicy.ExecuteAsync(async () =>
        {
            return await _context.Workouts.Where(p => p.UserEmail == UserEmail).ToListAsync(cancellationToken);
        });
    }

    public async Task CreateWorkout(Workout workout, CancellationToken cancellationToken)
    {
        await RetryPolicy.ExecuteAsync(async () =>
        {
            await _context.Workouts.AddAsync(workout, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        });
        Console.WriteLine($"Workout created with id: {workout.Id}");
    }

    public async Task DeleteWorkout(Guid workoutId, CancellationToken cancellationToken)
    {
        await RetryPolicy.ExecuteAsync(async () =>
        {
            await _context.Workouts.Where(w => w.Id == workoutId).ExecuteDeleteAsync(cancellationToken);
        });
    }
}
