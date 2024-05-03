namespace API.Endpoints.Workout.Get;

public class Request
{
    public required string UserEmail { get; set; }
    public required string Name { get; set; }
}
