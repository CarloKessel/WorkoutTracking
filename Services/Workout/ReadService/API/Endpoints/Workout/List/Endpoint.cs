using Application.Querys.Workout.List;
using FastEndpoints;

namespace API.Endpoints.Workout.List;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("workouts/user/{UserEmail}");
        Permissions("read:workouts");
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var query = new GetAllWorkoutsByUserEmailQuery(request.UserEmail);
        var response = await query.ExecuteAsync(cancellationToken);
        await SendOkAsync(new Response { Workouts = response.Workouts }, cancellationToken);
    }
}
