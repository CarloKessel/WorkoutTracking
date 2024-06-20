using Application.Models;

namespace Application.Querys.Exercise.Get;

public record GetExercisesByWorkoutIdResponse(
    List<ExerciseModel> Exercises
    );
