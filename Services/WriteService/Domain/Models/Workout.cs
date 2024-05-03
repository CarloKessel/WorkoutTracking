using Domain.Abstractions;
using Domain.Enum;

namespace Domain.Models;

public class Workout : Entity
{
    public string UserEmail { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public WorkoutType Type { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
