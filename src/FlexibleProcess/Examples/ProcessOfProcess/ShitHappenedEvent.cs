namespace FlexibleProcess.Examples.ProcessOfProcess;

class ShitHappenedEvent : Event<SystemInitiator>
{
    public ShitHappenedEvent(SystemInitiator emitter) : base(emitter)
    {
    }
}
