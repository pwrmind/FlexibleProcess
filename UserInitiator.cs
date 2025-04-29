namespace FlexibleProcess;

// Реализация инициатора для пользователя
public class UserInitiator : IEmitter
{
    public string Type => "Пользователь";
    public string Id { get; }

    public UserInitiator(string id)
    {
        Id = id;
    }
}
