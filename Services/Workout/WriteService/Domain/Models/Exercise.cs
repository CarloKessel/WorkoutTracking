using Domain.Abstractions;

namespace Domain.Models;

public class Exercise : Entity
{
    public Guid WorkoutId { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTime DateCreated { get; set; } = DateTime.UtcNow;
}
