namespace AWS.Sample.Domain.Persistence.Filters;

public class TaskItemFilter
{
    public TaskItemFilter()
    {
    }
    
    public TaskItemFilter(
        IEnumerable<int>? ids = null,
        string? searchString = null,
        bool? isComplete = null)
    {
        Ids = ids ?? [];
        SearchString = searchString;
        IsComplete = isComplete;
    }

    public IEnumerable<int> Ids { get; } = [];
    public string? SearchString { get; set; }
    public bool? IsComplete { get; set; }
}