namespace FlexibleProcess.Examples.TaskManagement;

/// <summary>
/// Represents data for a single task in the task management system
/// </summary>
public class TaskData
{
    /// <summary>
    /// Unique identifier of the task
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Title of the task
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Description of the task
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Priority of the task (1-5, where 5 is highest)
    /// </summary>
    public int Priority { get; set; }

    /// <summary>
    /// Estimated completion time in minutes
    /// </summary>
    public int EstimatedTime { get; set; }

    /// <summary>
    /// Actual time spent on the task in minutes
    /// </summary>
    public int TimeSpent { get; set; }

    public override string ToString()
    {
        return $"Task #{Id}: {Title} (Priority: {Priority}, Est: {EstimatedTime}m, Spent: {TimeSpent}m)";
    }
} 