namespace FlexibleProcess;

public class SystemInitiator : IEmitter
{
    public string Type => "Система";
    public string Id { get; }

    public SystemInitiator(string id)
    {
        Id = id;
    }
}
