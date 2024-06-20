using FastEndpoints;

namespace Application.Querys.Exercise.Get;

public record GetExercisesByWorkoutIdQuery(
    int WorkoutId
    ) : ICommand<GetExercisesByWorkoutIdResponse>;
