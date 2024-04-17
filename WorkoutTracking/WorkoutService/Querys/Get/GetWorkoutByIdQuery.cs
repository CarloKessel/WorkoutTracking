using FastEndpoints;

namespace WorkoutService.Querys.Get;

public record GetWorkoutByIdQuery(
    Guid WorkoutId
    ) : ICommand<GetWorkoutByIdResponse>;
