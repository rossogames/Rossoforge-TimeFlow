using Rossoforge.Events.Bus;

namespace Rossoforge.TimeFlow.Events
{
    public readonly struct TimeFlowResumedEvent : IEvent
    {
        public readonly float TimeScale;

        public TimeFlowResumedEvent(float timeScale)
        {
            TimeScale = timeScale;
        }
    }
}
