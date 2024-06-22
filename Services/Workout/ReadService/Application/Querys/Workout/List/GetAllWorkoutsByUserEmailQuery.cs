using FastEndpoints;

namespace Application.Querys.Workout.List;

public record GetAllWorkoutsByUserEmailQuery(
    string UserEmail
    ) : ICommand<GetAllWorkoutsByUserEmailResponse>;
