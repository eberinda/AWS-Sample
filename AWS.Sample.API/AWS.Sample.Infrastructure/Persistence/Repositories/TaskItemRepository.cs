using AWS.Sample.Domain.Persistence.Entities;
using AWS.Sample.Domain.Persistence.Filters;
using AWS.Sample.Domain.Persistence.Repositories;
using AWS.Sample.Infrastructure.Persistence.Repositories.Queries;

namespace AWS.Sample.Infrastructure.Persistence.Repositories;

public class TaskItemRepository : ITaskItemRepository
{
    private readonly IAWSDbContext _context;

    public TaskItemRepository(IAWSDbContext context)
    {
        _context = context;
    }

    public async Task<List<TaskItem>> SearchAsync(TaskItemFilter filter)
    {
        return await new TaskItemQuery(_context)
            .SetFilter(filter)
            .SelectAsync();
    }

    public async Task<TaskItem> InsertAsync(TaskItem taskItem)
    {
        await _context.TaskItems.AddAsync(taskItem);
        await _context.SaveChangesAsync();
        
        return taskItem;
    }

    public async Task<TaskItem> UpdateAsync(TaskItem taskItem)
    {
        var item = await new TaskItemQuery(_context)
            .SetFilter(new TaskItemFilter(ids: [taskItem.Id]))
            .FirstOrDefaultAsync();
        
        if (item is null) throw new Exception("Task item not found");
        
        item.Name = taskItem.Name;
        item.IsComplete = taskItem.IsComplete;
        
        _context.TaskItems.Update(item);
        await _context.SaveChangesAsync();
        
        return item;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var query = await new TaskItemQuery(_context)
            .SetFilter(new TaskItemFilter(ids: [id]))
            .FirstOrDefaultAsync();
        
        if (query is null) return false;
        
        _context.TaskItems.Remove(query);
        await _context.SaveChangesAsync();
        
        return true;
    }
}