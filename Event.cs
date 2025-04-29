namespace FlexibleProcess;

public class Event
{
    public string Name { get; private set; }
    public IEmitter Emitter { get; private set; } // Инициатор события

    public Event(string name, IEmitter emitter)
    {
        Name = name;
        Emitter = emitter;
    }

    public override string ToString()
    {
        return $"{Name} (Инициатор: {Emitter.Type})";
    }
}
