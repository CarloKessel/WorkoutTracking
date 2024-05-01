using WorkoutService.Models;

namespace WorkoutService.Endpoints.GetAll;

public class Response
{
    public List<Workout> workouts { get; set; } = new List<Workout>();
}
