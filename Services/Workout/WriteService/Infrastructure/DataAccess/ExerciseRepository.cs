using Application.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataAccess;

public class ExerciseRepository : IExerciseRepository
{
    private readonly WTContext _context;

    public ExerciseRepository(WTContext context)
    {
        _context = context;
    }

    public async Task<int> CreateExercise(Exercise exercise, CancellationToken cancellationToken)
    {
        await _context.Exercises.AddAsync(exercise, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return exercise.Id;
    }

    public async Task DeleteExercise(int exerciseId, CancellationToken cancellationToken)
    {
        await _context.Exercises.Where(w => w.Id == exerciseId).ExecuteDeleteAsync(cancellationToken);
    }
}
