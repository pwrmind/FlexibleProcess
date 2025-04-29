namespace FlexibleProcess;

/// <summary>
/// Represents an event that can trigger transitions between stages in a process.
/// Each event has an associated emitter that initiated it.
/// </summary>
public class Event
{
    /// <summary>
    /// The name of the event
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// The entity that emitted this event
    /// </summary>
    public IEmitter Emitter { get; private set; } // Инициатор события

    /// <summary>
    /// Initializes a new instance of the Event class
    /// </summary>
    /// <param name="name">The name of the event</param>
    /// <param name="emitter">The entity that emitted the event</param>
    public Event(string name, IEmitter emitter)
    {
        Name = name;
        Emitter = emitter;
    }

    /// <summary>
    /// Returns a string representation of the event
    /// </summary>
    /// <returns>A string containing the event name and emitter type</returns>
    public override string ToString()
    {
        return $"{Name} (Инициатор: {Emitter.Type})";
    }
}
