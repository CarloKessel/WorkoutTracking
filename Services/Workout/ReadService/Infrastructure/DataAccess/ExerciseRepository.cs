using Application.Interfaces;
using Domain.Models;
using Application.Context;
using Microsoft.EntityFrameworkCore;

namespace Application.DataAccess;

public class ExerciseRepository : IExerciseRepository
{
    private readonly WTContext _context;

    public ExerciseRepository(WTContext context)
    {
        _context = context;
    }

    public async Task<List<Exercise>> GetExercisesByWorkoutId(int workoutId, CancellationToken cancellationToken)
    {
        List<Exercise> exercises = await _context.Exercises.Where(e => e.WorkoutId == workoutId).ToListAsync();
        return exercises;
    }

    public async Task CreateExercise(Exercise exercise, CancellationToken cancellationToken)
    {
        await _context.Exercises.AddAsync(exercise, cancellationToken);
        var id = await _context.SaveChangesAsync(cancellationToken);
        Console.WriteLine($"Exercise created with id: {id}");
    }

    public async Task DeleteExercise(int exerciseId, CancellationToken cancellationToken)
    {
        await _context.Exercises.Where(w => w.Id == exerciseId).ExecuteDeleteAsync(cancellationToken);
    }
}
