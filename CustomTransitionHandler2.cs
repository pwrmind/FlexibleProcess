namespace FlexibleProcess;

/// <summary>
/// Another example of a custom transition handler for Package objects.
/// Implements different transition logic compared to CustomTransitionHandler1.
/// </summary>
/// <typeparam name="T">The type of data associated with the process</typeparam>
public class CustomTransitionHandler2<T> : TransitionHandler<T>
{
    /// <summary>
    /// Executes custom transition logic when moving between stages
    /// </summary>
    /// <param name="fromStage">The source stage</param>
    /// <param name="toStage">The target stage</param>
    /// <param name="processData">The data associated with the process</param>
    public override void Execute(Stage fromStage, Stage toStage, T processData)
    {
        Console.WriteLine($"Custom handler 2: Transitioning from {fromStage.Name} to {toStage.Name}");
        Console.WriteLine($"Processing data: {processData}");
        // Add custom transition logic here
    }
}
