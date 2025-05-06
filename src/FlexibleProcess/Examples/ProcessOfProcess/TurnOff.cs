namespace FlexibleProcess.Examples.ProcessOfProcess;

class TurnOff : Event<SystemInitiator>
{
    public TurnOff(SystemInitiator emitter) : base(emitter)
    {
    }
}
