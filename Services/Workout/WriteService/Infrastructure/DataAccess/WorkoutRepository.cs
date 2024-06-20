using Application.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class WorkoutRepository : IWorkoutRepository
{
    private readonly WTContext _context;

    public WorkoutRepository(WTContext context)
    {
        _context = context;
    }

    public async Task<int> CreateWorkout(Workout workout, CancellationToken cancellationToken)
    {
        await _context.Workouts.AddAsync(workout, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return workout.Id;
    }

    public async Task DeleteWorkout(int workoutId, CancellationToken cancellationToken)
    {
        await _context.Workouts.Where(w => w.Id == workoutId).ExecuteDeleteAsync(cancellationToken);
    }
}