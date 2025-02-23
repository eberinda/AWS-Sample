namespace AWS.Sample.Domain.ServiceModels;

public class TaskItemDto : IAuditableServiceModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public bool IsComplete { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}