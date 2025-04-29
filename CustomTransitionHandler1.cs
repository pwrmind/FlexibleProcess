namespace FlexibleProcess;

/// <summary>
/// Example of a custom transition handler for Package objects.
/// Implements specific logic for handling transitions between stages.
/// </summary>
/// <typeparam name="T">The type of data associated with the process</typeparam>
public class CustomTransitionHandler1<T> : TransitionHandler<T>
{
    /// <summary>
    /// Executes custom transition logic when moving between stages
    /// </summary>
    /// <param name="fromStage">The source stage</param>
    /// <param name="toStage">The target stage</param>
    /// <param name="processData">The data associated with the process</param>
    public override void Execute(Stage fromStage, Stage toStage, T processData)
    {
        Console.WriteLine($"Custom handler 1: Transitioning from {fromStage.Name} to {toStage.Name}");
        Console.WriteLine($"Processing data: {processData}");
        // Add custom transition logic here
    }
}
