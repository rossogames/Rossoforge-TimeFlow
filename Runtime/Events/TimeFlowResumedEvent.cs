using Rossoforge.Events.Bus;

namespace Rossoforge.TimeFlow
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
