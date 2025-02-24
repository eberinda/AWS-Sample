using AWS.Sample.Domain.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace AWS.Sample.Infrastructure.Persistence;

public interface IAWSDbContext
{
    DbSet<TaskItem> TaskItems { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}