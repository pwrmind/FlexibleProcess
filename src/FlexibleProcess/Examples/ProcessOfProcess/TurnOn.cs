namespace FlexibleProcess.Examples.ProcessOfProcess;

class TurnOn : Event<SystemInitiator>
{
    public TurnOn(SystemInitiator emitter) : base(emitter)
    {
    }
}
