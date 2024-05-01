using FastEndpoints;
using WorkoutService.Querys.ListFromUser;

namespace WorkoutService.Endpoints.GetAll;

public class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Get("/workout/UserEmail={UserEmail}");
        Permissions("read:workouts");
    }

    public override async Task HandleAsync(Request request, CancellationToken cancellationToken)
    {
        var query = new ListAllWorkoutsFromUserQuery(request.UserEmail);
        var response = await query.ExecuteAsync(cancellationToken);
        await SendOkAsync(new Response { workouts = response.Workouts }, cancellationToken);
    }
}
