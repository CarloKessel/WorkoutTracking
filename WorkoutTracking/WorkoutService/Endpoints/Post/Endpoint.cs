using FastEndpoints;
using WorkoutService.Commands.Post;

namespace WorkoutService.Endpoints.Post;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/workout");
        Permissions("add:workout");
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var command = new AddNewWorkoutCommand(request.UserEmail, request.Name);
        var result = await command.ExecuteAsync(cancellationToken);

        await SendCreatedAtAsync<Get.Endpoint>(result.WorkoutId, new Response() { Id = result.WorkoutId }, cancellation: cancellationToken);
    }
}
