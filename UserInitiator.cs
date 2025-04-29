namespace FlexibleProcess;

/// <summary>
/// Represents a user as an event emitter in the process.
/// </summary>
public class UserInitiator : IEmitter
{
    /// <summary>
    /// Gets the type of the emitter, which is "User" for this class
    /// </summary>
    public string Type => "User";

    /// <summary>
    /// Gets the unique identifier of the user
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Initializes a new instance of the UserInitiator class
    /// </summary>
    /// <param name="id">The unique identifier of the user</param>
    public UserInitiator(string id)
    {
        Id = id;
    }
}
