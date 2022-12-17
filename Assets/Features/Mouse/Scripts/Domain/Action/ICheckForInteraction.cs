using Features.Core.Scripts.Domain;
using Features.Mouse.Scripts.Provider;

namespace Features.Mouse.Scripts.Domain.Action
{
    public interface ICheckForInteraction
    {
        void Execute(IInteractable interactable);
    }
}