using AWS.Sample.Domain.Persistence.Filters;
using AWS.Sample.Domain.ServiceModels;

namespace AWS.Sample.Domain.Services;

public interface ITaskItemService
{
    public Task<List<TaskItemDto>> SearchAsync(TaskItemFilter filter);
    public Task<TaskItemDto> InsertAsync(TaskItemDto taskItemDto);
    public Task<TaskItemDto> UpdateAsync(TaskItemDto taskItemDto);
    public Task<bool> DeleteAsync(int id);
}