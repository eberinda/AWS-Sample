using AWS.Sample.Domain.Persistence;
using AWS.Sample.Domain.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AWS.Sample.Infrastructure.Persistence;

public class AWSDbContext : DbContext, IAWSDbContext
{
    public AWSDbContext(DbContextOptions<AWSDbContext> options) : base(options)
    {
    }
    
    public DbSet<TaskItem> TaskItems { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AWSDbContext).Assembly);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var entries = ChangeTracker.Entries()
            .Where(e => e is { Entity: IAuditableEntity, State: EntityState.Added or EntityState.Modified });
        
        foreach (var entry in entries)
        {
            if (entry.State == EntityState.Added)
            {
                ((IAuditableEntity)entry.Entity).CreatedAt = DateTimeOffset.UtcNow;
            }
            
            ((IAuditableEntity)entry.Entity).UpdatedAt = DateTimeOffset.UtcNow;
        }
        
        return await base.SaveChangesAsync(cancellationToken);
    }
}