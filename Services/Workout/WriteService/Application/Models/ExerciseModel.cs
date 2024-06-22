namespace Application.Models;

public class ExerciseModel
{
    public Guid Id { get; set; }
    public Guid WorkoutId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
