﻿using Features.Core.Scripts.Delivery;
using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Infrastructure;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class HoveringService
    {
        private readonly IHoveringRepository _repository;

        public HoveringService(IHoveringRepository repository) => _repository = repository;

        public void UpdateHovering(IHoverable currentAgent)
        {
            _repository.SetPrevious(_repository.GetCurrentHoverable());
            _repository.SetCurrent(currentAgent);
        }

        public void CheckForOnHoveringStart()
        {
            var previousAgent = _repository.GetPreviousHoverable();
            var currentAgent = _repository.GetCurrentHoverable();
            
            if (IsHoveringAnAgent() && IsHoveringDifferentAgent())
                currentAgent.OnHoveringStart();

            bool IsHoveringAnAgent() => currentAgent != null;
            bool IsHoveringDifferentAgent() => currentAgent != previousAgent;
        }
        
        public void CheckForOnHovering()
        {
            var previousAgent = _repository.GetPreviousHoverable();
            var currentAgent = _repository.GetCurrentHoverable();
            
            if (IsHoveringAnAgent() && IsHoveringSameAgent())
                currentAgent.OnHovering();

            bool IsHoveringAnAgent() => currentAgent != null;
            bool IsHoveringSameAgent() => currentAgent == previousAgent;
        }
        
        public void CheckForOnHoveringEnd()
        {
            var previousAgent = _repository.GetPreviousHoverable();
            var currentAgent = _repository.GetCurrentHoverable();
            
            if (IsNotHoveringAnAgent() && WasHoveringAnAgent())
                previousAgent.OnHoveringEnd();

            bool IsNotHoveringAnAgent() => currentAgent == null;
            bool WasHoveringAnAgent() => currentAgent != previousAgent;
            
        }
    }
}