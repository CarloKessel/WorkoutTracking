using Application.Commands.Exercise.Post;
using FastEndpoints;

namespace API.Endpoints.Exercise.Post;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("exercise");
        Permissions("write:exercises");
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var command = new AddNewExerciseCommand(request.WorkoutId, request.Name);
        var result = await command.ExecuteAsync(cancellationToken);

        await SendCreatedAtAsync(":5001/read-api/exercise/" + result.ExerciseId, result.ExerciseId, new Response() { Id = result.ExerciseId }, cancellation: cancellationToken);
    }
}
