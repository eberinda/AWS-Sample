using AWS.Sample.Domain.Persistence.Entities;
using AWS.Sample.Domain.Persistence.Filters;

namespace AWS.Sample.Domain.Persistence.Repositories;

public interface ITaskItemRepository
{
    public Task<List<TaskItem>> SearchAsync(TaskItemFilter filter);
    
    public Task<TaskItem> InsertAsync(TaskItem taskItem);
    public Task<TaskItem> UpdateAsync(TaskItem taskItem);
    public Task<bool> DeleteAsync(int id);
}