using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain
{
    public interface IHoveringRepository
    {
        IAgentView GetPreviousAgent();
        IAgentView GetCurrentAgent();
        void SetCurrent(IAgentView currentAgent);
        void SetPrevious(IAgentView previousAgent);
    }
}