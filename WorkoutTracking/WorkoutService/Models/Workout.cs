using WorkoutService.Enums;

namespace WorkoutService.Models;

public class Workout
{
    public Guid Id { get; set; }
    public string UserEmail { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public WorkoutType Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
