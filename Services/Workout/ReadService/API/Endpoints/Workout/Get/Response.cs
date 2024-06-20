using Application.Models;

namespace API.Endpoints.Workout.Get;

public class Response
{
    public WorkoutModel Workout { get; set; } = new WorkoutModel();
}
