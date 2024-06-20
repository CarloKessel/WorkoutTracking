using Application.Interfaces;
using Domain.Models;
using Application.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess;

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

    public async Task<List<Workout>> ListAllWorkoutsFromUserEmail(string UserEmail, CancellationToken cancellationToken)
    {
        var workouts = await _context.Workouts.Where(p => p.UserEmail == UserEmail).ToListAsync(cancellationToken);
        return workouts;
    }

    public async Task CreateWorkout(Workout workout, CancellationToken cancellationToken)
    {
        await _context.Workouts.AddAsync(workout, cancellationToken);
        var id = await _context.SaveChangesAsync(cancellationToken);
        Console.WriteLine($"Workout created with id: {id}");
    }

    public async Task DeleteWorkout(int workoutId, CancellationToken cancellationToken)
    {
        await _context.Workouts.Where(w => w.Id == workoutId).ExecuteDeleteAsync(cancellationToken);
    }
}
