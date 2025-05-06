namespace FlexibleProcess.Examples.ProcessOfProcess;
class Program
{
    static void Main(string[] args)
    {
        // Create stages for individual tasks
        Stage processIdle = new("Idle");
        Stage processRun = new("Run");
        Stage processComplete = new("Complete");

        SystemInitiator system = new("SYS-001");

        ShitHappenedEvent toIdle = new(system);
        FunHappenedEvent toRun = new(system);
        LoveHappenedEvent toComplete = new(system);

        var shipping = new Process<Shipping>(processIdle, new Shipping(42, "#4321"));
        var shippingProcess = new Process<Process<Shipping>>(processIdle, shipping);

        shippingProcess.AddStage(processRun);
        shippingProcess.AddStage(processComplete);

        // Create transition guards and handlers
        var processGuard = new ProcessTransitionGuard();
        var processHandler = new ProcessTransitionHandler();

        // Add transitions for tasks
        var toIdleTransition = new Transition<Process<Shipping>>(typeof(ShitHappenedEvent), processRun, processIdle, processHandler, processGuard);
        var toRunTransition = new Transition<Process<Shipping>>(typeof(FunHappenedEvent), processIdle, processRun, processHandler, processGuard);
        var toCompleteTransition = new Transition<Process<Shipping>>(typeof(LoveHappenedEvent), processRun, processComplete, processHandler, processGuard);

        // Add transitions to process
        shippingProcess.AddTransition(toIdleTransition);
        shippingProcess.AddTransition(toRunTransition);
        shippingProcess.AddTransition(toCompleteTransition);

        Console.WriteLine("Starting process demonstration...\n");

        shippingProcess.HandleEvent(toRun);
        shippingProcess.HandleEvent(toIdle);
        shippingProcess.HandleEvent(toRun);
        shippingProcess.HandleEvent(toComplete);
    }
}
