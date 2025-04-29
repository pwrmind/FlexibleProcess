namespace FlexibleProcess;

public class Transition<T>
{
    public Stage FromStage { get; private set; } // Исходный этап
    public Event TriggerEvent { get; private set; } // Событие, вызывающее переход
    public Stage ToStage { get; private set; } // Целевой этап
    public TransitionHandler<T> Handler { get; private set; } // Обработчик перехода
    private TransitionGuard<T> Guard; // Поле для функции проверки состояния

    // Конструктор принимает инициализацию StateGuard
    public Transition(Stage fromStage, Event triggerEvent, Stage toStage, TransitionHandler<T> handler = null, TransitionGuard<T> guard = null)
    {
        FromStage = fromStage;
        TriggerEvent = triggerEvent;
        ToStage = toStage;
        Handler = handler ?? new TransitionHandler<T>(); // По умолчанию базовый обработчик
        Guard = guard ?? new TransitionGuard<T>(); // Используем экземпляр TransitionGuard для текущего типа данных
    }

    // Метод для вызова проверки состояния и выполнения перехода
    public void ExecuteHandler(T processData)
    {
        if (!Guard.Validate(processData))
        {
            Console.WriteLine($"Переход: {FromStage.Name} -> {ToStage.Name} (по событию: {TriggerEvent}) невозможен: текущее состояние объекта - {processData}.");
			return;
        }

        Handler.Execute(FromStage, ToStage, processData); // Вызов обработчика перехода
    }

    public override string ToString()
    {
        return $"Переход: {FromStage.Name} -> {ToStage.Name} (по событию: {TriggerEvent})";
    }
}