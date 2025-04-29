namespace FlexibleProcess;

public class CustomTransitionHandler2<T> : TransitionHandler<T>
{
    public override void Execute(Stage fromStage, Stage toStage, T processData)
    {
        base.Execute(fromStage, toStage, processData);
        Console.WriteLine($"Данные процесса: {processData}");
        Console.WriteLine("Выполняется другая логика для CustomTransitionHandler2...");
    }
}
