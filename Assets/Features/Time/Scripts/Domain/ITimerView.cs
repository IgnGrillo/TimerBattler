using Features.Core.Scripts;

namespace Features.Time.Scripts.Domain
{
    public interface ITimerView
    {
        event FloatDelegate OnTimerUpdate;
        float GetTimeToTick();
        void UpdateTimerDisplay(float elapsedTime);
    }
}