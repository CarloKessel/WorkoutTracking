namespace API.Endpoints.Exercise.Post;

public class Request
{
    public required Guid WorkoutId {  get; set; }
    public required string Name { get; set; }
}
