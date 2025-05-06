namespace FlexibleProcess.Examples.ProcessOfProcess;

public class ProcessTransitionHandler : TransitionHandler<Process<Shipping>>
{
    public override void Execute(Stage fromStage, Stage toStage, Process<Shipping> process)
    {
        Console.WriteLine($"Process #{process.Id} transition: {fromStage.Name} -> {toStage.Name}");

        switch (toStage.Name)
        {
            case "On":
                Console.WriteLine($"Starting work on process: #{process.Id}");
                break;

            case "Off":
                Console.WriteLine($"Completing task: #{process.Id}");
                break;
        }
    }
} 