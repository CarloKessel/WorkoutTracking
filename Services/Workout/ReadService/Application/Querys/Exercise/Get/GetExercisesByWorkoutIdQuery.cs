using FastEndpoints;

namespace Application.Querys.Exercise.Get;

public record GetExercisesByWorkoutIdQuery(
    Guid WorkoutId
    ) : ICommand<GetExercisesByWorkoutIdResponse>;
