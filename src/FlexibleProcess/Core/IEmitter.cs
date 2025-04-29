namespace FlexibleProcess;

/// <summary>
/// Interface for entities that can emit events in the process.
/// Defines the basic properties that all event emitters must have.
/// </summary>
public interface IEmitter
{
    /// <summary>
    /// The type of the emitter (e.g., "User", "System", "ExternalService")
    /// </summary>
    string Type { get; }

    /// <summary>
    /// The unique identifier of the emitter
    /// </summary>
    string Id { get; }
}
