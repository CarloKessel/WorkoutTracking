using Application.Models;

namespace API.Endpoints.Exercise.Get;

public class Response
{
    public List<ExerciseModel> Exercises { get; set; } = new List<ExerciseModel>();
}
