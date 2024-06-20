namespace Application.Models;

public class ExerciseModel
{
    public int Id { get; set; }
    public int WorkoutId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
