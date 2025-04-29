namespace FlexibleProcess;

/// <summary>
/// Base class for validating transitions between stages in a process.
/// Provides default implementation that can be overridden by custom guards.
/// </summary>
/// <typeparam name="T">The type of data associated with the process</typeparam>
public class TransitionGuard<T>
{
    /// <summary>
    /// Validates whether a transition can occur based on the current process data
    /// </summary>
    /// <param name="processData">The data associated with the process</param>
    /// <returns>True if the transition is valid, false otherwise</returns>
    public virtual bool Validate(T processData)
    {
        // Default implementation allows all transitions
        // Override this method in derived classes to add custom validation logic
        return true;
    }
}
