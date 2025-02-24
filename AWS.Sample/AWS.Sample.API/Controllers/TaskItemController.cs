using AWS.Sample.Domain.Persistence.Filters;
using AWS.Sample.Domain.ServiceModels;
using AWS.Sample.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace AWS.Sample.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TaskItemController : ControllerBase
{
    private readonly ITaskItemService _taskItemService;

    public TaskItemController(ITaskItemService taskItemService)
    {
        _taskItemService = taskItemService;
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery]TaskItemFilter filter)
    {
        var taskItems = await _taskItemService.SearchAsync(filter);        
        return Ok(taskItems);
    }
    
    [HttpPost]
    public async Task<IActionResult> Post([FromBody]TaskItemDto taskItemDto)
    {
        var taskItem = await _taskItemService.InsertAsync(taskItemDto);
        return Ok(taskItem);
    }
    
    [HttpPut]
    public async Task<IActionResult> Put([FromBody]TaskItemDto taskItemDto)
    {
        var taskItem = await _taskItemService.UpdateAsync(taskItemDto);
        return Ok(taskItem);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute]int id)
    {
        var result = await _taskItemService.DeleteAsync(id);
        return Ok(result);
    }
}