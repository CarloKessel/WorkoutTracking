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

    public async Task<Workout> GetWorkoutById(int workoutId, CancellationToken cancellationToken)
    {
        var workout = await _context.Workouts.FindAsync(workoutId, cancellationToken);
        return workout ?? throw new Exception("Did not find workout.");
    }

    public async Task<List<Workout>> ListAllWorkoutsFromUserId(string UserEmail, CancellationToken cancellationToken)
    {
        var workouts = await _context.Workouts.Where(p => p.UserEmail == UserEmail).ToListAsync(cancellationToken);
        return workouts;
    }
}
