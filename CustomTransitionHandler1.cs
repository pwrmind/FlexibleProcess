namespace FlexibleProcess;

public class CustomTransitionHandler1<T> : TransitionHandler<T>
{
    public override void Execute(Stage fromStage, Stage toStage, T processData)
    {
        base.Execute(fromStage, toStage, processData);
        Console.WriteLine($"Данные процесса: {processData}");
        Console.WriteLine("Выполняется дополнительная логика для CustomTransitionHandler1...");
    }
}
