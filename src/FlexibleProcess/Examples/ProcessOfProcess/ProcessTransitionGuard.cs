namespace FlexibleProcess.Examples.ProcessOfProcess;

public class ProcessTransitionGuard : TransitionGuard<Process<Shipping>>
{
    public override bool Validate(Process<Shipping> process)
    {
        if (process == null)
        {
            Console.WriteLine("Process is null");
            return false;
        }
        
        return true;
    }
}
