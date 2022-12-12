using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain
{
    public interface IHoveringRepository
    {
        IAgentView Get();
        void Set(IAgentView currentAgent);
    }
}