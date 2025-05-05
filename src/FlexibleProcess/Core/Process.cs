namespace FlexibleProcess;

/// <summary>
/// Represents a generic process that can manage multiple stages and transitions.
/// The process is associated with specific data of type T.
/// </summary>
/// <typeparam name="T">The type of data associated with the process</typeparam>
public class Process<T>
{
    /// <summary>
    /// Id the process
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// List of all stages in the process
    /// </summary>
    public List<Stage> Stages { get; private set; }

    /// <summary>
    /// The current stage of the process
    /// </summary>
    public Stage CurrentStage { get; private set; }

    /// <summary>
    /// History of all transitions and events in the process
    /// </summary>
    public List<string> History { get; private set; }

    /// <summary>
    /// List of all possible transitions between stages
    /// </summary>
    private List<Transition<T>> _transitions;

    /// <summary>
    /// Data associated with the process
    /// </summary>
    private T _processData;

    /// <summary>
    /// Initializes a new instance of the Process class
    /// </summary>
    /// <param name="initialStage">The starting stage of the process</param>
    /// <param name="processData">The data associated with the process</param>
    public Process(Stage initialStage, T processData)
    {
        Id = Guid.NewGuid();
        Stages = new List<Stage> { initialStage };
        CurrentStage = initialStage;
        History = new List<string> { $"Начало процесса: {CurrentStage.Name}" };
        _transitions = new List<Transition<T>>();
        _processData = processData;
    }

    /// <summary>
    /// Adds a new stage to the process
    /// </summary>
    /// <param name="stage">The stage to add</param>
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

    /// <summary>
    /// Adds a new transition between stages
    /// </summary>
    /// <param name="transition">The transition to add</param>
    public void AddTransition(Transition<T> transition)
    {
        _transitions.Add(transition);
        Console.WriteLine($"Добавлен переход: {transition}");
    }

    /// <summary>
    /// Handles an event and performs the corresponding transition if valid
    /// </summary>
    /// <param name="eventName">The event to handle</param>
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

    /// <summary>
    /// Prints the history of all transitions in the process
    /// </summary>
    public void PrintHistory()
    {
        Console.WriteLine("История переходов:");
        foreach (var entry in History)
        {
            Console.WriteLine(entry);
        }
    }
}
