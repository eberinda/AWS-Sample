using AWS.Sample.Domain.Persistence.Entities;
using AWS.Sample.Domain.Persistence.Filters;
using AWS.Sample.Domain.Persistence.Repositories;
using AWS.Sample.Domain.ServiceModels;
using AWS.Sample.Domain.Services;
using Mapster;

namespace AWS.Sample.Application.Services;

public class TaskItemService : ITaskItemService
{
    private readonly ITaskItemRepository _taskItemRepository;

    public TaskItemService(ITaskItemRepository taskItemRepository)
    {
        _taskItemRepository = taskItemRepository;
    }
    
    public async Task<List<TaskItemDto>> SearchAsync(TaskItemFilter filter)
    {
        var taskItems = await _taskItemRepository.SearchAsync(filter);
        return taskItems.Adapt<List<TaskItemDto>>();
    }

    public async Task<TaskItemDto> InsertAsync(TaskItemDto taskItemDto)
    {
        var taskItem = taskItemDto.Adapt<TaskItem>();
        var result = await _taskItemRepository.InsertAsync(taskItem);
        return result.Adapt<TaskItemDto>();
    }

    public async Task<TaskItemDto> UpdateAsync(TaskItemDto taskItemDto)
    {
        var taskItem = taskItemDto.Adapt<TaskItem>();
        var result = await _taskItemRepository.UpdateAsync(taskItem);
        return result.Adapt<TaskItemDto>();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        return await _taskItemRepository.DeleteAsync(id);
    }
}