namespace AWS.Sample.Domain.Persistence.Entities;

public class TaskItem : IAuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsComplete { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; } 
}