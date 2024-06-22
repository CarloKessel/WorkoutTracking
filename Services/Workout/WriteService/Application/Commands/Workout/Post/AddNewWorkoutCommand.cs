using FastEndpoints;

namespace Application.Commands.Workout.Post;

public record AddNewWorkoutCommand(
    string UserEmail,
    string Name
    ) : ICommand<AddNewWorkoutResponse>;
