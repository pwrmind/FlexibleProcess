namespace FlexibleProcess.Examples.TaskManagement;

/// <summary>
/// Represents data for a list of tasks being managed by the main process
/// </summary>
public class TaskListData
{
    /// <summary>
    /// Unique identifier of the task list
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Name of the task list
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// List of individual task processes
    /// </summary>
    public List<Process<TaskData>> Tasks { get; set; }

    /// <summary>
    /// Total number of tasks
    /// </summary>
    public int TotalTasks => Tasks.Count;

    /// <summary>
    /// Number of completed tasks
    /// </summary>
    public int CompletedTasks => Tasks.Count(t => t.CurrentStage.Name == "Complete");

    /// <summary>
    /// Number of tasks in progress
    /// </summary>
    public int InProgressTasks => Tasks.Count(t => t.CurrentStage.Name == "Run");

    /// <summary>
    /// Number of idle tasks
    /// </summary>
    public int IdleTasks => Tasks.Count(t => t.CurrentStage.Name == "Idle");

    public TaskListData(int id, string name)
    {
        Id = id;
        Name = name;
        Tasks = new List<Process<TaskData>>();
    }

    public override string ToString()
    {
        return $"Task List #{Id}: {Name} (Total: {TotalTasks}, Completed: {CompletedTasks}, In Progress: {InProgressTasks}, Idle: {IdleTasks})";
    }
} 