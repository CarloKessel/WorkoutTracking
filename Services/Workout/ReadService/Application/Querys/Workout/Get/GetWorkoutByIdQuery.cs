using FastEndpoints;

namespace Application.Querys.Workout.Get;

public record GetWorkoutByIdQuery(
    int WorkoutId
    ) : ICommand<GetWorkoutByIdResponse>;
