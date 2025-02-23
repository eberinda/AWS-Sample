namespace AWS.Sample.Domain.Persistence;

public interface IAuditableEntity
{
    public int Id { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdatedAt { get; set; }
}