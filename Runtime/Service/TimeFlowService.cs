using Rossoforge.Core.Events;
using Rossoforge.Core.Services;
using Rossoforge.Core.TimeFlow;
using Rossoforge.Services;
using System;
using UnityEngine;

namespace Rossoforge.TimeFlow.Service
{
    public class TimeFlowService : ITimeFlowService, IInitializable
    {
        private IEventService _eventService;
        private float _previousTimeScale = 1f;
        private float _baseFixedDeltaTime;

        public bool IsPaused { get; private set; }

        public void Initialize()
        {
            _baseFixedDeltaTime = Time.fixedDeltaTime;
            _eventService = ServiceLocator.Get<IEventService>();
        }

        public virtual DateTime GetCurrentUtcTime()
        {
            return DateTime.UtcNow;
        }

        public void PauseTimeFlow()
        {
            if (IsPaused)
                return;

            _previousTimeScale = Time.timeScale;
            SetTimeScale(0);

            IsPaused = true;
            _eventService.Raise<TimeFlowPausedEvent>();
        }

        public void ResumeTimeFlow()
        {
            if (!IsPaused)
                return;

            var targetScale = _previousTimeScale <= 0f ? 1f : _previousTimeScale;
            SetTimeScale(targetScale);

            IsPaused = false;
            _eventService.Raise(new TimeFlowResumedEvent(targetScale));
        }

        private void SetTimeScale(float timeScale)
        {
            if (timeScale < 0f) 
                timeScale = 0f;

            Time.timeScale = timeScale;
            Time.fixedDeltaTime = _baseFixedDeltaTime * timeScale;
        }
    }
}
