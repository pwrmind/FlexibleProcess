namespace FlexibleProcess.Examples.TaskManagement;

/// <summary>
/// Custom transition handler for TaskData objects
/// </summary>
public class TaskTransitionHandler : TransitionHandler<TaskData>
{
    /// <summary>
    /// Executes custom transition logic when moving between stages
    /// </summary>
    public override void Execute(Stage fromStage, Stage toStage, TaskData task)
    {
        Console.WriteLine($"Task #{task.Id} transition: {fromStage.Name} -> {toStage.Name}");

        switch (toStage.Name)
        {
            case "Run":
                Console.WriteLine($"Starting work on task: {task.Title}");
                task.TimeSpent = 0;
                break;

            case "Complete":
                Console.WriteLine($"Completing task: {task.Title}");
                Console.WriteLine($"Time spent: {task.TimeSpent}m (Estimated: {task.EstimatedTime}m)");
                break;

            case "Idle":
                Console.WriteLine($"Task {task.Title} is now idle");
                break;
        }
    }
} 