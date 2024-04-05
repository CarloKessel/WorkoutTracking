using FastEndpoints;

namespace WorkoutService.Commands.Post;

public record AddNewWorkoutCommand(
    string Name
    ) : ICommand<AddNewWorkoutResponse>;
