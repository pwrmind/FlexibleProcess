namespace FlexibleProcess;

/// <summary>
/// Represents the system as an event emitter in the process.
/// Used for automated or system-generated events.
/// </summary>
public class SystemInitiator : IEmitter
{
    /// <summary>
    /// Gets the type of the emitter, which is "System" for this class
    /// </summary>
    public string Type => "System";

    /// <summary>
    /// Gets the unique identifier of the system component
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the SystemInitiator class
    /// </summary>
    /// <param name="id">The unique identifier of the system component</param>
    public SystemInitiator(string id)
    {
        Id = id;
    }
}
