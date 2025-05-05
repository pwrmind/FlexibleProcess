namespace FlexibleProcess.Examples.ProcessOfProcess;

public class ProcessTransitionHandler : TransitionHandler<Process<Shipping>>
{
    public override void Execute(Stage fromStage, Stage toStage, Process<Shipping> process)
    {
        Console.WriteLine($"Process #{process.Id} transition: {fromStage.Name} -> {toStage.Name}");

        switch (toStage.Name)
        {
            case "Run":
                Console.WriteLine($"Starting work on process: #{process.Id}");
                break;

            case "Complete":
                Console.WriteLine($"Completing task: #{process.Id}");
                break;

            case "Idle":
                Console.WriteLine($"Task {process.Id} is now idle");
                break;
        }
    }
} 