using Features.Core.Scripts;
using Features.Core.Scripts.Domain;
using Features.Time.Scripts.Domain;
using UnityEngine;

namespace Features.Time.Scripts.Presentation
{
    public class TimerPresenter
    {
        private readonly ITimerView _view;
        private readonly IEventBus _eventBus;
        private float _currentTimer;
        private float _timeToTick;
        private bool _isTimeStopped;

        public TimerPresenter(ITimerView view, IEventBus eventBus)
        {
            _view = view;
            _eventBus = eventBus;
        }

        public void Initialize()
        {
            _eventBus.SubscribeToEmission(GameEvent.OnTimerStop, OnTimeStop);
            _timeToTick = _view.GetTimeToTick();
            _view.OnTimerUpdate += OnTimerUpdate;
        }

        private void OnTimeStop() => _isTimeStopped = true;

        private void OnTimerUpdate(float time)
        {
            if (_isTimeStopped) return;
            
            UpdateCurrentTime();
            UpdateDisplay();
            CheckForTick();

            void UpdateCurrentTime() => _currentTimer += time;
            void UpdateDisplay() => _view.UpdateTimerDisplay(Mathf.Min(_currentTimer/_timeToTick, 1f));
            void CheckForTick()
            {
                if (!IsItTimeToTick()) return;
                TriggerTick();

                bool IsItTimeToTick() => _currentTimer >= _timeToTick;
                void TriggerTick()
                {
                    _currentTimer -= _timeToTick;
                    _eventBus.EmitEvent(GameEvent.OnTimerUpdate);
                }
            }
        }
    }
}