namespace AWS.Sample.Domain.ServiceModels;

public interface IAuditableServiceModel
{
    public int Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}