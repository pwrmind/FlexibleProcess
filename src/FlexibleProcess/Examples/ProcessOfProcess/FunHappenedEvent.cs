namespace FlexibleProcess.Examples.ProcessOfProcess;

class FunHappenedEvent : Event<SystemInitiator>
{
    public FunHappenedEvent(SystemInitiator emitter) : base(emitter)
    {
    }
}
