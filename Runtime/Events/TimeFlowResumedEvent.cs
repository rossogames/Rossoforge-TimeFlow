using Rossoforge.Core.Events;

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
