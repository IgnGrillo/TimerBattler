using System;

namespace Features.Core.Scripts.Domain
{
    public interface IEventBus
    {
        void EmitEvent(GameEvent emittedEvent);
        void SubscribeToEmission(GameEvent emittedEvent, Action actionToExecute);
        void Unsubscribe(GameEvent onTimerUpdate, Action advanceSkillsCooldown);
    }
}