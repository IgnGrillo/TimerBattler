using Features.Core.Scripts.Delivery;
using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain;

namespace Features.Mouse.Scripts.Infrastructure
{
    public class InMemoryHoveringRepository : IHoveringRepository
    {
        private IAgentView _currentlyHoveringAgent;

        public IAgentView Get() => _currentlyHoveringAgent;
        public void Set(IAgentView currentAgent) => _currentlyHoveringAgent = currentAgent;
    }
}