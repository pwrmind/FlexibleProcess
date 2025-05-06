namespace FlexibleProcess;

/// <summary>
/// Represents an event that can trigger transitions between stages in a process.
/// Each event has an associated emitter that initiated it.
/// </summary>
public abstract class Event<TEmitter> //where TEmitter: IEmitter
{
    /// <summary>
    /// The name of the event
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// The entity that emitted this event
    /// </summary>
    public TEmitter Emitter { get; private set; } // Инициатор события

    /// <summary>
    /// Initializes a new instance of the Event class
    /// </summary>
    /// <param name="name">The name of the event</param>
    /// <param name="emitter">The entity that emitted the event</param>
    public Event(TEmitter emitter)
    {
        Id = Guid.NewGuid();
        Emitter = emitter;
    }

    /// <summary>
    /// Returns a string representation of the event
    /// </summary>
    /// <returns>A string containing the event name and emitter type</returns>
    public override string ToString()
    {
        return $"{Id} (Инициатор: {Emitter})";
    }
}
