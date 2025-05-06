namespace FlexibleProcess.Examples.ProcessOfProcess;

class LoveHappenedEvent : Event<SystemInitiator>
{
    public LoveHappenedEvent(SystemInitiator emitter) : base(emitter)
    {
    }
}
