namespace FlexibleProcess;

public class ExternalServiceInitiator : IEmitter
{
    public string Type => "Внешний сервис";
    public string Id { get; }

    public ExternalServiceInitiator(string id)
    {
        Id = id;
    }
}
