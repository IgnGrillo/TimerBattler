using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action
{
    public interface IUpdateHoveringAgent
    {
        void Execute(IHoverable hoverable);
    }
}