using FastEndpoints;

namespace Application.Querys.Workout.Get;

public record GetWorkoutByIdQuery(
    Guid WorkoutId
    ) : ICommand<GetWorkoutByIdResponse>;
