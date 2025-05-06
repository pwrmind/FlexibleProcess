namespace FlexibleProcess.Examples.ProcessOfProcess;
class Program
{
    static void Main(string[] args)
    {
        // Create stages for individual tasks
        Stage turnedOn = new("On");
        Stage turnedOff = new("Off");

        var shipping = new Process<Shipping>(new Shipping(42, "#4321"));
        var shippingProcess = new Process<Process<Shipping>>(shipping);

        shippingProcess.AddStage(turnedOff);
        shippingProcess.AddStage(turnedOn);

        // Create transition guards and handlers
        var processGuard = new ProcessTransitionGuard();
        var processHandler = new ProcessTransitionHandler();

        // Add transitions for tasks
        var toIdleTransition = new Transition<Process<Shipping>>(typeof(TurnOn), turnedOff, turnedOn, processHandler, processGuard);
        var toRunTransition = new Transition<Process<Shipping>>(typeof(TurnOff), turnedOn, turnedOff, processHandler, processGuard);

        // Add transitions to process
        shippingProcess.AddTransition(toIdleTransition);
        shippingProcess.AddTransition(toRunTransition);

        Console.WriteLine("Starting process demonstration...\n");

        SystemInitiator system = new("SYS-001");

        shippingProcess.HandleEvent(new TurnOn(system));
        shippingProcess.HandleEvent(new TurnOff(system));
        shippingProcess.HandleEvent(new TurnOn(system));
        shippingProcess.HandleEvent(new TurnOff(system));
    }
}
