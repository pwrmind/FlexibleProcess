namespace FlexibleProcess.Examples.ProcessOfProcess;

class Program
{
    static void Main(string[] args)
    {
        // Create stages for individual tasks
        Stage processIdle = new Stage("Idle");
        Stage processRun = new Stage("Run");
        Stage processComplete = new Stage("Complete");

        IEmitter system = new SystemInitiator("SYS-001");

        Event toIdle = new Event("IdleProcess", system);
        Event toRun = new Event("RunProcess", system);
        Event toComplete = new Event("CompleteProcess", system);

        var shipping = new Process<Shipping>(processIdle, new Shipping(42, "#4321"));
        var shippingProcess = new Process<Process<Shipping>>(processIdle, shipping);

        shippingProcess.AddStage(processRun);
        shippingProcess.AddStage(processComplete);

        // Create transition guards and handlers
        var processGuard = new ProcessTransitionGuard();
        var processHandler = new ProcessTransitionHandler();

        // Add transitions for tasks
        var toIdleTransition = new Transition<Process<Shipping>>(processRun, toIdle, processIdle, processHandler, processGuard);
        var toRunTransition = new Transition<Process<Shipping>>(processIdle, toRun, processRun, processHandler, processGuard);
        var toCompleteTransition = new Transition<Process<Shipping>>(processRun, toComplete, processComplete, processHandler, processGuard);

        // Add transitions to process
        shippingProcess.AddTransition(toIdleTransition);
        shippingProcess.AddTransition(toRunTransition);
        shippingProcess.AddTransition(toCompleteTransition);

        Console.WriteLine("Starting process demonstration...\n");
        Console.WriteLine("Starting process...");
        
        shippingProcess.HandleEvent(toRun);
        shippingProcess.HandleEvent(toIdle);
        shippingProcess.HandleEvent(toRun);
        shippingProcess.HandleEvent(toComplete);
    }
}
