using Features.Core.Scripts.Domain;

namespace Features.Mouse.Scripts.Domain.Action.Interaction
{
    public interface ICheckForInteraction
    {
        void Execute(IInteractable interactable);
    }
}