namespace FlexibleProcess;

public class TransitionHandler<T>
{
    public virtual void Execute(Stage fromStage, Stage toStage, T processData)
    {
        Console.WriteLine($"Обработчик перехода: {fromStage.Name} -> {toStage.Name}");
        Console.WriteLine("Выполняется базовая логика перехода...");
    }
}
