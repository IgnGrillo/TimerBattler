using UnityEngine;

namespace Features.Time.Scripts.Delivery
{
    [CreateAssetMenu(order = 0, fileName = "DefaultTimeSettings", menuName = "TimeSettings")]
    public class TimerSettings : ScriptableObject
    {
        public float timeToActivateTimer = 4;
    }
}