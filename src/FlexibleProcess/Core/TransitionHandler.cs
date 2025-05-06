namespace FlexibleProcess;

/// <summary>
/// Base class for handling transitions between stages in a process.
/// Provides default implementation that can be overridden by custom handlers.
/// </summary>
/// <typeparam name="T">The type of data associated with the process</typeparam>
public class TransitionHandler<T>
{
    /// <summary>
    /// Executes the transition handler logic
    /// </summary>
    /// <param name="fromStage">The source stage</param>
    /// <param name="toStage">The target stage</param>
    /// <param name="processData">The data associated with the process</param>
    public virtual void Execute<TEmitter>(Event<TEmitter> eventInstance, Stage fromStage, Stage toStage, T processData)
    {
        // Default implementation does nothing
        // Override this method in derived classes to add custom transition logic
    }
}
