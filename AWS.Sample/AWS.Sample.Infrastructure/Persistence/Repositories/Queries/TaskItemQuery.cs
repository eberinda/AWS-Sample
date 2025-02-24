using AWS.Sample.Domain.Persistence.Entities;
using AWS.Sample.Domain.Persistence.Filters;
using AWS.Sample.Infrastructure.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AWS.Sample.Infrastructure.Persistence.Repositories.Queries;

public class TaskItemQuery
{
    private IQueryable<TaskItem> _query;

    public TaskItemQuery(IAWSDbContext context)
    {
        _query = context.TaskItems;
    }

    public TaskItemQuery AsNoTracking()
    {
        _query = _query.AsNoTracking();
        return this;
    }
    
    public TaskItemQuery SetFilter(TaskItemFilter filter)
    {
        _query = _query
            .WhereWhen(filter.Ids.Any(), x => filter.Ids.Contains(x.Id))
            .WhereWhen(!string.IsNullOrEmpty(filter.SearchString), x => x.Name.Contains(filter.SearchString!))
            .WhereWhen(filter.IsComplete.HasValue, x => x.IsComplete == filter.IsComplete);
        
        return this;
    }
    
    public async Task<List<TaskItem>> SelectAsync()
    {
        return await _query.ToListAsync();
    }
    
    public async Task<TaskItem?> FirstOrDefaultAsync()
    {
        return await _query.FirstOrDefaultAsync();
    }
}