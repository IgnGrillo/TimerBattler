using Features.Core.Scripts.Delivery;
using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Infrastructure;

namespace Features.Mouse.Scripts.Domain.Action
{
    public class HoveringService
    {
        private readonly IHoveringRepository _repository;

        public HoveringService(IHoveringRepository repository) => _repository = repository;

        public void UpdateHovering(IAgentView agentView)
        {
            var previousAgent = _repository.Get();
            _repository.Set(agentView);
            if(agentView != null && agentView != previousAgent)
            {
                agentView.OnHoveringStart();
            }
        }
    }
}