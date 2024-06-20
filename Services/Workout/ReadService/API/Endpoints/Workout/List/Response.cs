using Application.Models;

namespace API.Endpoints.Workout.List;

public class Response
{
    public List<WorkoutModel> Workouts { get; set; } = new List<WorkoutModel>();
}
