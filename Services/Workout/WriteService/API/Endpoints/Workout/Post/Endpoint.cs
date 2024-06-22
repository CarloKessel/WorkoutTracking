using Application.Commands.Workout.Post;
using FastEndpoints;

namespace API.Endpoints.Workout.Get;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("workout");
        Permissions("write:workouts");
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var command = new AddNewWorkoutCommand(request.UserEmail, request.Name);
        var result = await command.ExecuteAsync(cancellationToken);

        await SendCreatedAtAsync(":5001/read-api/workout/" + result.WorkoutId, result.WorkoutId, new Response() { Id = result.WorkoutId }, cancellation: cancellationToken);
    }
}
