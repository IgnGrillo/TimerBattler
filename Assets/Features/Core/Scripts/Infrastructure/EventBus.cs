using System;
using System.Collections.Generic;
using Features.Core.Scripts.Domain;

namespace Features.Core.Scripts.Infrastructure
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<GameEvent, List<Action>> _eventsSubscriptions;
        public EventBus() => _eventsSubscriptions = new Dictionary<GameEvent, List<Action>>();

        public void EmitEvent(GameEvent emittedEvent)
        {
            foreach (var action in _eventsSubscriptions[emittedEvent])
                action.Invoke();
        }

        public void SubscribeToEmission(GameEvent emittedEvent, Action actionToExecute)
        {
            if (!_eventsSubscriptions.ContainsKey(emittedEvent))
                _eventsSubscriptions.Add(emittedEvent, new List<Action>() { actionToExecute });
            else _eventsSubscriptions[emittedEvent].Add(actionToExecute);
        }

        public void Unsubscribe(GameEvent emittedEvent, Action actionToExecute)
        {
            try
            {
                _eventsSubscriptions[emittedEvent].Remove(actionToExecute);
            }
            catch (KeyNotFoundException)
            {
                throw new ActionSubscriptionNotFound();
            }
        }
    }
}