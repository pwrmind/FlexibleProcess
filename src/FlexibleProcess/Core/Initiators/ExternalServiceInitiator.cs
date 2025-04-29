namespace FlexibleProcess;

/// <summary>
/// Represents an external service as an event emitter in the process.
/// Used for events triggered by external systems or services.
/// </summary>
public class ExternalServiceInitiator : IEmitter
{
    /// <summary>
    /// Gets the type of the emitter, which is "ExternalService" for this class
    /// </summary>
    public string Type => "ExternalService";

    /// <summary>
    /// Gets the unique identifier of the external service
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the ExternalServiceInitiator class
    /// </summary>
    /// <param name="id">The unique identifier of the external service</param>
    public ExternalServiceInitiator(string id)
    {
        Id = id;
    }
}
