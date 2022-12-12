using System;
using System.Globalization;
using Features.Core.Scripts;
using Features.Time.Scripts.Domain;
using TMPro;
using UnityEngine;

namespace Features.Time.Scripts.Delivery
{
    public class TimerView : MonoBehaviour, ITimerView
    {
        [SerializeField] private TimerSettings _timerSettings;
        [SerializeField] private TMP_Text _timeText;
        
        private float _timeToTick;
        
        public event FloatDelegate OnTimerUpdate;

        private void OnEnable() => _timeToTick = _timerSettings.timeToActivateTimer;
        
        public float GetTimeToTick() => _timerSettings.timeToActivateTimer;
        public void UpdateTimerDisplay(float elapsedTime) => _timeText.text = $"{elapsedTime.ToString(CultureInfo.InvariantCulture)}/{_timeToTick}";
    }
}