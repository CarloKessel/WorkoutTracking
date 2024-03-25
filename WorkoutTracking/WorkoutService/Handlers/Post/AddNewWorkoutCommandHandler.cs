using FastEndpoints;
using WorkoutService.Commands.Post;

namespace WorkoutService.Handlers.Post;

public class AddNewWorkoutCommandHandler : CommandHandler<AddNewWorkoutCommand, AddNewWorkoutResponse>
{
    public override Task<AddNewWorkoutResponse> ExecuteAsync(AddNewWorkoutCommand command, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
