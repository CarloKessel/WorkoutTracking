using WorkoutService.Enums;

namespace WorkoutService.Models;

public class Workout
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; } = string.Empty;
    public WorkoutType Type { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
