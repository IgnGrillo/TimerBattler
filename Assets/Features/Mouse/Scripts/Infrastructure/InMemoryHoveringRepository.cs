using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Domain;

namespace Features.Mouse.Scripts.Infrastructure
{
    public class InMemoryHoveringRepository : IHoveringRepository
    {
        private IAgentView _previousAgent;
        private IAgentView _currentAgent;

        public IAgentView GetPreviousAgent() => _previousAgent;
        public IAgentView GetCurrentAgent() => _currentAgent;

        public void SetCurrent(IAgentView currentAgent) => _currentAgent = currentAgent;
        public void SetPrevious(IAgentView previousAgent) => _previousAgent = previousAgent;
    }
}