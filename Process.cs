namespace FlexibleProcess;

public class Process<T>
{
    public List<Stage> Stages { get; private set; }
    public Stage CurrentStage { get; private set; }
    public List<string> History { get; private set; }
    private List<Transition<T>> _transitions;
    private T _processData;

    public Process(Stage initialStage, T processData)
    {
        Stages = new List<Stage> { initialStage };
        CurrentStage = initialStage;
        History = new List<string> { $"Начало процесса: {CurrentStage.Name}" };
        _transitions = new List<Transition<T>>();
        _processData = processData;
    }

    public void AddStage(Stage stage)
    {
        if (Stages.Exists(s => s.Name == stage.Name))
        {
            Console.WriteLine($"Этап '{stage.Name}' уже существует в процессе.");
        }
        else
        {
            Stages.Add(stage);
            Console.WriteLine($"Этап '{stage.Name}' добавлен в процесс.");
        }
    }

    // Добавление перехода
    public void AddTransition(Transition<T> transition)
    {
        _transitions.Add(transition);
        Console.WriteLine($"Добавлен переход: {transition}");
    }

    // Обработка события и выполнение перехода
    public void HandleEvent(Event eventName)
    {
        var transition = _transitions.Find(t => t.FromStage == CurrentStage && t.TriggerEvent == eventName);

        if (transition != null)
        {
            // Можно добавить дополнительные обработчики до и после перехода
            transition.ExecuteHandler(_processData); // Вызов обработчика перехода с данными процесса
            CurrentStage = transition.ToStage;
            History.Add($"Переход на этап: {CurrentStage.Name} (по событию: {eventName}, Инициатор: {eventName.Emitter.Type} (ID: {eventName.Emitter.Id}))");
            Console.WriteLine($"Переход на этап: {CurrentStage} (по событию: {eventName}, Инициатор: {eventName.Emitter.Type} (ID: {eventName.Emitter.Id}))");
        }
        else
        {
            Console.WriteLine($"Невозможно обработать событие: {eventName} на этапе: {CurrentStage.Name}");
        }
    }

    // Вывод истории переходов
    public void PrintHistory()
    {
        Console.WriteLine("История переходов:");
        foreach (var entry in History)
        {
            Console.WriteLine(entry);
        }
    }
}
