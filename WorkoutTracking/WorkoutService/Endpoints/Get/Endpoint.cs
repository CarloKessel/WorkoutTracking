using FastEndpoints;
using WorkoutService.Querys.Get;

namespace WorkoutService.Endpoints.Get;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/workout/{WorkoutId}");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var query = new GetWorkoutByIdQuery(request.WorkoutId);
        var response = await query.ExecuteAsync(cancellationToken);
        await SendOkAsync(new Response { Name = response.Name }, cancellationToken);
    }
}
