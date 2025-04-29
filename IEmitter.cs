namespace FlexibleProcess;

public interface IEmitter
{
    string Type { get; } // Тип инициатора (например, "Пользователь", "Система")
    string Id { get; }   // Идентификатор инициатора
}
