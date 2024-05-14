using FastEndpoints;

namespace Application.Commands.Post;

public record AddNewWorkoutCommand(
    string UserEmail,
    string Name
    ) : ICommand<AddNewWorkoutResponse>;
