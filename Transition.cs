namespace FlexibleProcess;

/// <summary>
/// Represents a transition between two stages in a process, triggered by an event.
/// Includes validation and handling logic for the transition.
/// </summary>
/// <typeparam name="T">The type of data associated with the process</typeparam>
public class Transition<T>
{
    /// <summary>
    /// The source stage of the transition
    /// </summary>
    public Stage FromStage { get; private set; }

    /// <summary>
    /// The event that triggers this transition
    /// </summary>
    public Event TriggerEvent { get; private set; }

    /// <summary>
    /// The target stage of the transition
    /// </summary>
    public Stage ToStage { get; private set; }

    /// <summary>
    /// The handler that executes when the transition occurs
    /// </summary>
    public TransitionHandler<T> Handler { get; private set; }

    /// <summary>
    /// The guard that validates if the transition can occur
    /// </summary>
    private TransitionGuard<T> Guard;

    /// <summary>
    /// Initializes a new instance of the Transition class
    /// </summary>
    /// <param name="fromStage">The source stage</param>
    /// <param name="triggerEvent">The event that triggers the transition</param>
    /// <param name="toStage">The target stage</param>
    /// <param name="handler">Optional custom handler for the transition</param>
    /// <param name="guard">Optional custom guard for the transition</param>
    public Transition(Stage fromStage, Event triggerEvent, Stage toStage, TransitionHandler<T> handler = null, TransitionGuard<T> guard = null)
    {
        FromStage = fromStage;
        TriggerEvent = triggerEvent;
        ToStage = toStage;
        Handler = handler ?? new TransitionHandler<T>(); // Default handler if none provided
        Guard = guard ?? new TransitionGuard<T>(); // Default guard if none provided
    }

    /// <summary>
    /// Executes the transition handler after validating the transition is possible
    /// </summary>
    /// <param name="processData">The data associated with the process</param>
    public void ExecuteHandler(T processData)
    {
        if (!Guard.Validate(processData))
        {
            Console.WriteLine($"Переход: {FromStage.Name} -> {ToStage.Name} (по событию: {TriggerEvent}) невозможен: текущее состояние объекта - {processData}.");
            return;
        }

        Handler.Execute(FromStage, ToStage, processData); // Execute the transition handler
    }

    /// <summary>
    /// Returns a string representation of the transition
    /// </summary>
    /// <returns>A string describing the transition</returns>
    public override string ToString()
    {
        return $"Переход: {FromStage.Name} -> {ToStage.Name} (по событию: {TriggerEvent})";
    }
}