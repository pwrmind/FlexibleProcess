namespace FlexibleProcess.Examples.TaskManagement;

/// <summary>
/// Custom transition guard for TaskData objects
/// </summary>
public class TaskTransitionGuard : TransitionGuard<TaskData>
{
    /// <summary>
    /// Validates whether a transition can occur for a task
    /// </summary>
    public override bool Validate(TaskData task)
    {
        if (task == null)
        {
            Console.WriteLine("Task is null");
            return false;
        }

        if (task.Id <= 0)
        {
            Console.WriteLine($"Invalid task ID: {task.Id}");
            return false;
        }

        if (string.IsNullOrEmpty(task.Title))
        {
            Console.WriteLine("Task title is empty");
            return false;
        }

        if (task.Priority < 1 || task.Priority > 5)
        {
            Console.WriteLine($"Invalid task priority: {task.Priority}");
            return false;
        }

        if (task.EstimatedTime <= 0)
        {
            Console.WriteLine($"Invalid estimated time: {task.EstimatedTime}");
            return false;
        }

        return true;
    }
} 