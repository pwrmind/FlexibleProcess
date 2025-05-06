namespace FlexibleProcess.Examples.ProcessOfProcess;
class Program
{
    static void Main(string[] args)
    {
        // Create stages for individual tasks
        Stage turnedOn = new("On");
        Stage turnedOff = new("Off");

        SystemInitiator system = new("SYS-001");

        TurnOn turnOn = new(system);
        TurnOff turnOff = new(system);

        var shipping = new Process<Shipping>(turnedOff, new Shipping(42, "#4321"));
        var shippingProcess = new Process<Process<Shipping>>(turnedOff, shipping);

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

        shippingProcess.HandleEvent(turnOn);
        shippingProcess.HandleEvent(turnOff);
        shippingProcess.HandleEvent(turnOn);
        shippingProcess.HandleEvent(turnOff);
    }
}
