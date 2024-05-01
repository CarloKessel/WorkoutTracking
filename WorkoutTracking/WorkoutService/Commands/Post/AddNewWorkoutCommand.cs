using FastEndpoints;

namespace WorkoutService.Commands.Post;

public record AddNewWorkoutCommand(
    string UserEmail,
    string Name
    ) : ICommand<AddNewWorkoutResponse>;
